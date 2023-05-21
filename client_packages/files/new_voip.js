
const localPlayer = mp.players.local;

const Use3d = true;
const UseAutoVolume = true;

const MaxRange = 10.0;


let talkinginradio = false;


let isspying = false;
mp.events.add("spymg", (stats,target) => {
    if (global.chatopened || global.logged === 0) return;

    if (stats) {
        mp.voiceChat.muted = true;
        isspying = false;
        g_voiceMgr.remove(target);
        voice_radio.rlisteners.forEach((player) => {
            voice_radio.padd(player);
        });
    } else {
        if (mp.voiceChat.muted) {

            isspying = true;
            voice_radio.rlisteners.forEach((player) => {
                voice_radio.premove(player);
            });

            g_voiceMgr.listeners.forEach((player) => {
                g_voiceMgr.remove(player);
            });

            g_voiceMgr.add(target);
            mp.voiceChat.muted = false;


        }
    }
   

});
const enableMicrophone = () => {
    try {

    
    if (global.chatopened || global.logged === 0) return;

	
        if (mp.voiceChat.muted) {


        voice_radio.rlisteners.forEach((player) => {
                voice_radio.premove(player);
        });

        g_voiceMgr.listeners.forEach((player) => {
            voice_radio.padd(player);
        });
       
        mp.voiceChat.muted = false;

            mp.events.call(`micstats`,true);
        localPlayer.playFacialAnim("mic_chatter", "mp_facial");
        mp.events.callRemote("enableVoiceInput", true);
		global.uiPlayer_Browsers.execute("SetPlayerVoice(true)");
        }
    } catch (e) {

    }
}

const disableMicrophone = () => {
    if (global.logged === 0) return;
    if (!mp.voiceChat.muted) {

        voice_radio.rlisteners.forEach((player) => {
            voice_radio.padd(player);
        });

        mp.voiceChat.muted = true;

        mp.events.call(`micstats`, false);
        localPlayer.playFacialAnim("mood_normal_1", "facials@gen_male@variations@normal");
        mp.events.callRemote("enableVoiceInput", false);
		global.uiPlayer_Browsers.execute("SetPlayerVoice(false)");
    }
}


mp.keys.bind(78, true, enableMicrophone);
mp.keys.bind(78, false, disableMicrophone);


mp.game.streaming.requestAnimDict("mp_facial");
mp.game.streaming.requestAnimDict("facials@gen_male@variations@normal");

let g_voiceMgr =
    {
        listeners: [],

        add: function (player, notify) {
            if (notify) mp.events.callRemote("add_voice_listener", player);
            if (this.listeners.indexOf(player) === -1) {
                this.listeners.push(player);
            }
            player.isListening = true;

            player.voice3d = true;
            player.voiceVolume = 0.0;
        },
        
        remove: function (player, notify) {
            let idx = this.listeners.indexOf(player);
            let idz = g_voiceMgr.listeners.indexOf(player);
            if (idz !== -1) {

                if (idx !== -1)
                    this.listeners.splice(idx, 1);

                player.isListening = false;

                if (notify && voice_radio.rlisteners.indexOf(player) === -1) {
                    mp.events.callRemote("remove_voice_listener", player);
                }
            }
            
        }
};

mp.events.add("showr", (player) => {
    voice_radio.rlisteners.forEach((player) => {
        mp.gui.chat.push(player.name+" Radio");
    });
});

mp.events.add("fixv1", (player) => {
    mp.voiceChat.cleanupAndReload(true, true, true);
    g_voiceMgr.listeners.forEach((player) => {

        player.isListening = false;
        g_voiceMgr.remove(player, true);
    });

    
});

mp.events.add("showg", (player) => {
    g_voiceMgr.listeners.forEach((player) => {
        mp.gui.chat.push(player.name + " Voice");
    });
});

mp.events.add("playerQuit", (player) => {
    if (g_voiceMgr.listeners.indexOf(player) !== -1) {
        g_voiceMgr.remove(player, false);
    }
    if (voice_radio.rlisteners.indexOf(player) !== -1) {
        voice_radio.remove(player, false);
    }

});

let PHONE = {
    target: null,
    status: false
};

mp.events.add('voice.mute', () => {
    disableMicrophone();
})
mp.events.add('voice.phoneCall', (target) => {
    if (!PHONE.target) {
        PHONE.target = target;
        PHONE.status = true;
        mp.events.callRemote("add_voice_listener", target);
        target.voiceVolume = 1.0;
        target.voice3d = false;
        g_voiceMgr.remove(target, false);
    }
});
mp.events.add("voice.phoneStop", () => {
    if (PHONE.target) {
        if (mp.players.exists(PHONE.target)) {
            let localPos = localPlayer.position;
            const playerPos = PHONE.target.position;
            let dist = mp.game.system.vdist(playerPos.x, playerPos.y, playerPos.z, localPos.x, localPos.y, localPos.z);

            if (dist > MaxRange) {
                mp.events.callRemote("remove_voice_listener", PHONE.target);
            } else {
                g_voiceMgr.add(PHONE.target, false);
            }
        } else {
            mp.events.callRemote("remove_voice_listener", PHONE.target);
        }

        PHONE.target = null;
        PHONE.status = false;
    }
});

let voice_radio =
{
    rlisteners: [],
    add: function (player,addtolist) {
        if (addtolist == true && this.rlisteners.indexOf(player) === -1) this.rlisteners.push(player);
        player.voice3d = false;
        player.voiceVolume = 1;
        mp.events.callRemote("add_voice_listener", player);
    },
    padd: function (player) {
        mp.events.callRemote("add_voice_listener", player);
    },
    premove: function (player) {
        mp.events.callRemote("remove_voice_listener", player);
    },
    remove: function (player,use) {
        let idx = this.rlisteners.indexOf(player);

        if (idx !== -1)
            this.rlisteners.splice(idx, 1);
        if (use && g_voiceMgr.listeners.indexOf(player) === -1) {
            mp.events.callRemote("remove_voice_listener", player);
        }
    }
};


const enableradio = () => {
	
    if (global.chatopened || global.logged === 0) return;
	
    if(localPlayer.getVariable('Radio_Status') == false || localPlayer.getVariable('RadioFreq') == 0) return;
	
    if (mp.voiceChat.muted) {

        voice_radio.rlisteners.forEach((player) => {
                voice_radio.padd(player);
        });

		mp.events.call("playClientSound", "radio_peer",0.2);
		mp.events.callRemote("TalkInRadio",true);

        mp.voiceChat.muted = false;
        //radiovoice = true;
        mp.events.call(`micstats`, true);
        localPlayer.playFacialAnim("missexile1_cargoplane", "call_radio_radio");
        global.uiPlayer_Browsers.execute("SetPlayerVoice(true)");
        talkinginradio = true;

    }
}

const disableradio= () => {
    if (global.logged === 0) return;
    if (!mp.voiceChat.muted) {
        mp.voiceChat.muted = true;
       // radiovoice = false;
        

		mp.events.callRemote("TalkInRadio",false);
        mp.events.call(`micstats`, false);
        localPlayer.playFacialAnim("mood_normal_1", "facials@gen_male@variations@normal");
        global.uiPlayer_Browsers.execute("SetPlayerVoice(false)");
        talkinginradio = false;

    }
}

mp.keys.bind(66, true, enableradio);
mp.keys.bind(66, false, disableradio);


mp.events.add('voice.radio', (target) => {
        voice_radio.add(target,true);
});

mp.events.add('v_disconnect', (target) => { 
    voice_radio.remove(target,true);
});

mp.events.add('r_reload', () => {
    voice_radio.rlisteners.forEach((player) => {
        mp.events.callRemote("add_voice_listener", player);
    });
});

mp.events.add('v_reload', () => {
    g_voiceMgr.listeners.forEach((player) => {
        mp.events.callRemote("add_voice_listener", player); // voice taraf vasat enable mishe faghat
    });
});


mp.events.add('v_checklisten', (player) => {
    mp.gui.chat.push(`isListening: ${player.isListening} | voiceActivity: ${player.isVoiceActive}`);
});

mp.events.add('playerStartTalking', (player) => {
    if (PHONE.target != player) player.voice3d = true;
	//mp.events.callRemote("TalkInRadio",true);
    player.playFacialAnim("mic_chatter", "mp_facial");
	//global.uiPlayer_Browsers.execute("SetPlayerVoice(true)");
});
mp.events.add('playerStopTalking', (player) => {
    player.playFacialAnim("mood_normal_1", "facials@gen_male@variations@normal");
	//mp.events.callRemote("TalkInRadio", false);
	//global.uiPlayer_Browsers.execute("SetPlayerVoice(false)");
});


function PlayerVoiceN()
{
    let localPlayer = mp.players.local;
    let localPos = localPlayer.position;

    mp.players.forEachInStreamRange(player => {
        if (player != localPlayer) {
            if (!player.isListening && (!PHONE.target || PHONE.target != player)) {
                const playerPos = player.position;
                let dist = mp.game.system.vdist(playerPos.x, playerPos.y, playerPos.z, localPos.x, localPos.y, localPos.z);

                if (dist <= MaxRange && isspying == false) {
                    g_voiceMgr.add(player, true);

                }
            }
        }
    });

    g_voiceMgr.listeners.forEach((player) => {
        if (mp.players.exists(player)) {
            let playerPos = player.position;
            let dist = mp.game.system.vdist(playerPos.x, playerPos.y, playerPos.z, localPos.x, localPos.y, localPos.z);

            if (dist > MaxRange) {
                g_voiceMgr.remove(player, true);
            }
            else if (UseAutoVolume) {
                if (g_voiceMgr.listeners.indexOf(player) === -1 && isspying == false) {
                    g_voiceMgr.add(player, true);
                }
                player.voiceVolume = 1.1 - (dist / MaxRange);
            }
        }
        else {
            g_voiceMgr.remove(player, true);
        }
    });
};

setInterval(() => {
    PlayerVoiceN();
}, 100);


// thanks to kemperrr
const scalable = (dist, maxDist) => Math.max(0.1, 1 - (dist / maxDist));
const clamp = (min, max, value) => Math.min(Math.max(min, value), max);

let nextFrameActive = false;

mp.events.add('render', () => {


    if (talkinginradio) {
        mp.game.controls.disableControlAction(2, 25, true);
        mp.game.controls.disableControlAction(1, 24, true);
    }
    mp.players.forEachInStreamRange(player => {
        if (player !== localPlayer) {
            const __playerPosition__ = player.position;
            const __localPlayerPosition__ = localPlayer.position;

            const distance = mp.game.system.vdist(__localPlayerPosition__.x, __localPlayerPosition__.y, __localPlayerPosition__.z, __playerPosition__.x, __playerPosition__.y, __playerPosition__.z);
            if (distance <= 25 && !player.isOccluded() && !player.isDead() && player.getVariable('INVISIBLE') != true) {

                const headPosition = player.getBoneCoords(12844, 0, 0, 0);
                const headPosition2d = mp.game.graphics.world3dToScreen2d(headPosition.x, headPosition.y, headPosition.z + 0.4);

                if (!headPosition2d) {
                    return false;
                }

                const scale = scalable(distance, 25);
                const scaleSprite = 0.7 * scale;

                const isMuted = false;
                const sprite = (!isMuted) ? 'leaderboard_audio_3' : 'leaderboard_audio_mute';

                const spriteColor = [255, 255, 255, 255];

                if (player.isVoiceActive) {
                    drawSprite("mpleaderboard", sprite, [scaleSprite, scaleSprite], 0, spriteColor, headPosition2d.x, headPosition2d.y + 0.038 * scale);
                }
            }
        }
    });
});

const drawSprite = (dist, name, scale, heading, colour, x, y, layer) => {
    const graphics = mp.game.graphics
        , resolution = graphics.getScreenActiveResolution(0, 0)
        , textureResolution = graphics.getTextureResolution(dist, name)
        , SCALE = [(scale[0] * textureResolution.x) / resolution.x, (scale[1] * textureResolution.y) / resolution.y]

    if (graphics.hasStreamedTextureDictLoaded(dist) === 1) {
        if (typeof layer === 'number') {
            graphics.set2dLayer(layer);
        }

        graphics.drawSprite(dist, name, x, y, SCALE[0], SCALE[1], heading, colour[0], colour[1], colour[2], colour[3]);
    } else {
        graphics.requestStreamedTextureDict(dist, true);
    }
};