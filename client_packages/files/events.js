
global.localplayer = mp.players.local;

global.bodyCam = null;
global.bodyCamStart = new mp.Vector3(0, 0, 0);
var attachedObjects = [];


// PEDOVI
mp.peds.new(368603149, new mp.Vector3(443.1894, -981.9881, 30.579), 84.7, 0); // pd placanje kazne
mp.peds.new(1581098148, new mp.Vector3(484.62, -1003.70, 25.73), 0.01, 0); // pd oruzaonica
mp.peds.new(664399832, new mp.Vector3(-553.73, -189.19, 38.11), -155.01, 0); // opstina
mp.peds.new(-756833660, new mp.Vector3(-637.47, -2257.812, 5.93), 164.81, 0); // autoskola
mp.peds.new(131961260, new mp.Vector3(-107.56066, -2706.5156, 6.007262), 90.01, 0); // krijumcar
mp.peds.new(1624626906, new mp.Vector3(4763.553, -4780.493, 3.8015196), 141.01, 0); // krijumcar 2
mp.peds.new(1401530684, new mp.Vector3(-1083.314, -245.69662, 38.03233), -150.15, 0); // hacker
mp.peds.new(666718676, new mp.Vector3(1272.18, -1712.11, 54.77), -68.88, 0); // ihacker
mp.peds.new(-317922106, new mp.Vector3(-68.16, 6255.84, 31.09), 119.89, 0); // pilicar
mp.peds.new(-317922106, new mp.Vector3(-679.30, 5834.16, 17.40), 140.19, 0); // pecurke
mp.peds.new(1798879480, new mp.Vector3(451.67, -622.06, 28.60), -96.11, 0); // bus vozac
mp.peds.new(-1709285806, new mp.Vector3(-594.28, 2090.51, 131.42), 18.52, 0); // rudar
mp.peds.new(-2051422616, new mp.Vector3(1639.4, 4879.4, 42.14), 91, 0); //blackmarket
mp.peds.new(-2051422616, new mp.Vector3(791.54, 2176.50, 52.64), -26.08, 0); //wanted
mp.peds.new(1535236204, new mp.Vector3(-1391.67, -604.96, 30.40), 111.01, 0); //bahamas
mp.peds.new(2014052797, new mp.Vector3(1983.18, 3053.44, 47.21), -117.75, 0); //racepub
mp.peds.new(-625565461, new mp.Vector3(-562.03, 286.69, 82.20), -98.98, 0); //tequilala
mp.peds.new(-44746786, new mp.Vector3(129.41, -1283.93, 29.08), 119.98, 0); //Club
mp.peds.new(1530648845, new mp.Vector3(1110.46, 208.35, -49.44), 119.98, 0); //casino alkohol
mp.peds.new(-317922106, new mp.Vector3(1332.72, 4325.29, 38.3), -15.11, 0); //Prodavac riba
mp.peds.new(-1382092357, new mp.Vector3(1231.85, -3006.80, 9.31), 90.59, 0); //Kupac Nakita
mp.peds.new(-730659924, new mp.Vector3(308.65, -595.32, 43.28), 60.04, 0); //Lekar
mp.peds.new(-771835772, new mp.Vector3(1258.95, -2572.59, 42.80), 5.24, 0); //autodelovi
mp.peds.new(-459818001, new mp.Vector3(149.68, -1698.50, 29.29), -49.04, 0); //diler
mp.peds.new(2010389054, new mp.Vector3(1020.80, -2892.44, 11.26), 175.04, 0); //diler2
mp.peds.new(-1280051738, new mp.Vector3(-126.01, -641.67, 168.82), 98.93, 0); //arcadius biznis
mp.peds.new(1095737979, new mp.Vector3(-56.25, -1098.58, 26.42), 27.93, 0); //smiljka u autoshopu
Ped = mp.peds.new(1381498905, new mp.Vector3(113.07, -1288.21, 28.45), -61.39, 0); //Club stripper 1
Ped2 = mp.peds.new(1846523796, new mp.Vector3(111.80, -1286.37, 28.45), -61.39, 0); //Club stripper 2

mp.events.add('privatedances', function () {
    mp.game.streaming.requestAnimDict("mini@strip_club@lap_dance_2g@ld_2g_p1");
    mp.game.streaming.requestAnimDict("mini@hookers_spcrackhead");
    Ped.taskPlayAnim("mini@strip_club@lap_dance_2g@ld_2g_p1","ld_2g_p1_s1", 8.0, 1.0, -1, 2, 0.0, false, false, false);
    Ped2.taskPlayAnim("mini@strip_club@lap_dance_2g@ld_2g_p1","ld_2g_p1_s1", 8.0, 1.0, -1, 2, 0.0, false, false, false);
});


// BODY CUSTOM //
function getCameraOffset(pos, angle, dist) {
    //mp.gui.chat.push(`Sin: ${Math.sin(angle)} | Cos: ${Math.cos(angle)}`);

    angle = angle * 0.0174533;

    pos.y = pos.y + dist * Math.sin(angle);
    pos.x = pos.x + dist * Math.cos(angle);

    //mp.gui.chat.push(`X: ${pos.x} | Y: ${pos.y}`);

    return pos;
}
var bodyCamValues = {
    "hair": { Angle: 0, Dist: 0.5, Height: 0.7 },
    "beard": { Angle: 0, Dist: 0.5, Height: 0.7 },
    "eyebrows": { Angle: 0, Dist: 0.5, Height: 0.7 },
    "chesthair": { Angle: 0, Dist: 1, Height: 0.2 },
    "lenses": { Angle: 0, Dist: 0.5, Height: 0.7 },

    "torso": [
        { Angle: 0, Dist: 1, Height: 0.2 },
        { Angle: 0, Dist: 1, Height: 0.2 },
        { Angle: 0, Dist: 1, Height: 0.2 },
        { Angle: 180, Dist: 1, Height: 0.2 },
        { Angle: 180, Dist: 1, Height: 0.2 },
        { Angle: 180, Dist: 1, Height: 0.2 },
        { Angle: 180, Dist: 1, Height: 0.2 },
        { Angle: 305, Dist: 1, Height: 0.2 },
        { Angle: 55, Dist: 1, Height: 0.2 },
    ],
    "head": [
        { Angle: 0, Dist: 1, Height: 0.5 },
        { Angle: 305, Dist: 1, Height: 0.5 },
        { Angle: 55, Dist: 1, Height: 0.5 },
        { Angle: 180, Dist: 1, Height: 0.5 },
        { Angle: 0, Dist: 0.5, Height: 0.5 },
        { Angle: 0, Dist: 0.5, Height: 0.5 },
    ],
    "leftarm": [
        { Angle: 55, Dist: 1, Height: 0.0 },
        { Angle: 55, Dist: 1, Height: 0.1 },
        { Angle: 55, Dist: 1, Height: 0.1 },
    ],
    "rightarm": [
        { Angle: 305, Dist: 1, Height: 0.0 },
        { Angle: 305, Dist: 1, Height: 0.1 },
        { Angle: 305, Dist: 1, Height: 0.1 },
    ],
    "leftleg": [
        { Angle: 55, Dist: 1, Height: -0.6 },
        { Angle: 55, Dist: 1, Height: -0.6 },
    ],
    "rightleg": [
        { Angle: 305, Dist: 1, Height: -0.6 },
        { Angle: 305, Dist: 1, Height: -0.6 },
    ],
};

mp.events.add('peds', () => {
    
});

mp.events.add("ps_BodyCamera", () => {
    
	bodyCamStart = localplayer.position;
    var camValues = { Angle: localplayer.getRotation(2).z + 93, Dist: 3.1, Height: 0.2 };
    var pos = getCameraOffset(new mp.Vector3(bodyCamStart.x, bodyCamStart.y, bodyCamStart.z + camValues.Height), camValues.Angle, camValues.Dist);
    bodyCam = mp.cameras.new('default', pos, new mp.Vector3(0, 0, 0), 50);
    bodyCam.pointAtCoord(bodyCamStart.x, bodyCamStart.y, bodyCamStart.z + camValues.Height);
    bodyCam.setActive(true);
    mp.game.cam.renderScriptCams(true, false, 500, true, false);
	
	localplayer.taskPlayAnim("amb@world_human_guard_patrol@male@base", "base", 8.0, 1, -1, 1, 0.0, false, false, false);
});

mp.events.add("ps_SetCamera", (id) => {

	// torso
	var camValues = { Angle: 0, Dist: 1, Height: 0.2 };
	switch(id)
	{
		case 0: // Torso
		{
			camValues = { Angle: 0, Dist: 2.6, Height: 0.2 };
			break;
		}
		case 1: // Head
		{
			camValues = { Angle: 0, Dist: 1, Height: 0.5 };
			break;
		}
		case 2: // Hair / Bear / Eyebrows
		{
			camValues = { Angle: 0, Dist: 0.5, Height: 0.7 };
			break;
		}
		case 3: // chesthair
		{
			camValues = { Angle: 0, Dist: 1, Height: 0.2 };
			break;
		}
	}

	const camPos = getCameraOffset(new mp.Vector3(bodyCamStart.x, bodyCamStart.y, bodyCamStart.z + camValues.Height), localplayer.getRotation(2).z + 90 + camValues.Angle, camValues.Dist);
	bodyCam.setCoord(camPos.x, camPos.y, camPos.z);
	bodyCam.pointAtCoord(bodyCamStart.x, bodyCamStart.y, bodyCamStart.z + camValues.Height);
	
});



mp.events.add("ps_DestroyCamera", () => {

    if (bodyCam == null) return;
    bodyCam.setActive(false);
    bodyCam.destroy();
    mp.game.cam.renderScriptCams(false, false, 3000, true, true);
	
    bodyCam = null;
	
});

mp.events.add("playScenario", () => {
	mp.players.local.taskStartScenarioInPlace('WORLD_HUMAN_CONST_DRILL', 0, false);
});

mp.events.add('screenFadeOut', function (duration) {
    mp.game.cam.doScreenFadeOut(duration);
});

mp.events.add('screenFadeIn', function (duration) {
    mp.game.cam.doScreenFadeIn(duration);
});

mp.events.add('showChat2', function (enable) {
    mp.gui.chat.show(enable);
    mp.gui.chat.activate(enable);
});

mp.events.add('enableInteriorProp', function (value, name) {
    mp.game.interior.enableInteriorProp(value, name);
	mp.game.interior.refreshInterior(value);
});


/*mp.events.add("ps_SetCameraEx", (id, id_2) => {
    
	const camValues = bodyCamValues[id][id_2];
	const camPos = getCameraOffset(new mp.Vector3(bodyCamStart.x, bodyCamStart.y, bodyCamStart.z + camValues.Height), localplayer.getRotation(2).z + 90 + camValues.Angle, camValues.Dist);

	bodyCam.setCoord(camPos.x, camPos.y, camPos.z);
	bodyCam.pointAtCoord(bodyCamStart.x, bodyCamStart.y, bodyCamStart.z + camValues.Height);
	
});*/

// Head Notification
class HeadNotification {
    constructor(text) {
        // why on earth does this take arguments? damn ragemp
        this.resolution = mp.game.graphics.getScreenActiveResolution(0, 0);

        this.text = text;
        this.startDuration = duration;
        var duration;
        this.alpha = 255;
        this.offset = 0;

        this.onUpdateEventHandler = mp.events.add('render', () => this.onUpdateHandler());
    }

    onUpdateHandler() {
        if (this.alpha <= 0) {
            return;
        }

        mp.game.graphics.drawText(
            this.text,
            [0.5, 0.5 + this.offset], {
            font: 4,
            color: [255, 255, 255, this.alpha],
            scale: [0.5, 0.5],
            outline: true
        });

        this.offset -= 0.0005;
        this.alpha -= 1;
    }
}

mp.events.add("createNewHeadNotificationAdvanced", (notificationText) => {
    new HeadNotification(notificationText);
});



mp.events.add("ShowSignToCreator", (dimension) => {
    mp.players.local.mugshotboard.show("NOVO PERSONAGEM", "", "000000001", "LOS SANTOS POLICE DEPT", 1, dimension);
});


// Peds
let Peds = [];
mp.events.add({

    "Sync_PedCreate": (name, model, position, heading = 0, callback, dimension = mp.players.local) => {
        let ped = mp.peds.new(model, position, heading, (streamPed) => streamPed.setAlpha(0), dimension);
        Peds[name] = ped;
		//ped.setSynchronizedSceneLooped("CODE_HUMAN_MEDIC_TIME_OF_DEATH", true);
		//ped.taskStartScenarioInPlace("CODE_HUMAN_MEDIC_TIME_OF_DEATH", -1, true);
    },
    
    "Sync_PedRemove": (name) => {
        if (!name) return;
        Peds[name].destroy();
        delete Peds[name];
    },

    "Sync_PutPedInVehicle": (name, veh, seat) => {
        if (!name || !veh) return;
        let ped = Peds[name];
        ped.taskEnterVehicle(veh.handle, -1, seat, 2, 16, 0);
    }

});

// Screen Effect and Drug Effects

mp.events.add("screen_cocaine", () => {
    mp.game.graphics.startScreenEffect("DrugsDrivingOut", 180000, false);
    //API.setPlayerIsDrunk(mp.players.local, true);
    mp.game.cam.shakeGameplayCam("DRUNK_SHAKE", 4);
});

mp.events.add("screen_cocaine_off", () => {
    mp.game.cam.stopGameplayCamShaking(true);
});

mp.events.add("screen_weed", () => {
    mp.game.graphics.startScreenEffect("DrugsMichaelAliensFight", 60000, false);
});

mp.events.add("screen_drunk", () => {
    mp.game.graphics.startScreenEffect("BikerFilter", 60000, false);
});

mp.events.add("screen_steroid", () => {
    mp.game.graphics.startScreenEffect("ChopVision", 60000, false);
    
});

mp.events.add("play_screen_effect", (effectName, duration, looped) => {
	mp.game.graphics.startScreenEffect(effectName, duration, looped);
});
	
mp.events.add("stop_screen_effect", (effectName) => {
    mp.game.graphics.stopScreenEffect(effectName);
});

mp.events.add("attachEntityToEntityForVehicles", (entity1, entity2, boneName, posOffset, rotOffset) => {
    AttachEntityToEntityForVehicles(entity1, entity2, boneName, posOffset, rotOffset);
});

function AttachEntityToEntityForVehicles(entity1, entity2, boneName, posOffset, rotOffset) {
	if (entity1 !== null && entity2 !== null)
		entity1.attachTo(entity2.handle, entity2.getBoneIndexByName(boneName), posOffset.x, posOffset.y, posOffset.z, rotOffset.x, rotOffset.y, rotOffset.z, true, true, false, true, 0, true);
}

mp.events.add("attachEntityToEntity", (entity1, entity2, boneIndex, posOffset, rotOffset) => {
    if (entity1 !== null && entity2 !== null)
		AttachEntityToEntity(entity1, entity2, boneIndex, posOffset, rotOffset);
});

function AttachEntityToEntity(entity1, entity2, boneIndex, posOffset, rotOffset) {
    entity1.attachTo(entity2.handle, entity2.getBoneIndex(boneIndex), posOffset.x, posOffset.y, posOffset.z, rotOffset.x, rotOffset.y, rotOffset.z, true, true, false, true, 0, true);
}

mp.events.add('movePosition', function (x, y, z) {
	localplayer.clearTasks();
	localplayer.taskGoStraightToCoord(x, y, z, 1, -1, 270, 1.0);
});

mp.events.add("screen_cocaine", () => {
    mp.game.graphics.startScreenEffect("DrugsDrivingOut", 180000, false);
    //API.setPlayerIsDrunk(mp.players.local, true);
    mp.game.cam.shakeGameplayCam("DRUNK_SHAKE", 4);
});

mp.events.add('attachObjectToPlayer', function (playerRemoteID, boneIndex, posOffset, rotOffset) {
	
	let playerHandle = mp.players.atHandle(playerRemoteID);

	playerHandle.getVariable('temp_object_handle').attachTo(playerHandle, playerHandle.getBoneIndex(boneIndex), posOffset.x, posOffset.y, posOffset.z, rotOffset.x, rotOffset.y, rotOffset.z, true, true, false, true, 0, true);
});

mp.events.add('attachObject', function attachObject(player) {
    try {
        if (player && mp.players.exists(player)) {
            if (attachedObjects[player.id] != undefined) attachedObjects[player.id].destroy();

            if (player.getVariable('attachedObject') == null) return;
            let data = JSON.parse(player.getVariable('attachedObject'));
            let boneID = player.getBoneIndex(data.Bone);
            var object = mp.objects.new(data.Model, player.position,
                {
                    rotation: new mp.Vector3(0, 0, 0),
                    alpha: 255,
                    dimension: player.dimension
                });
            setTimeout(() => { object.attachTo(player.handle, boneID, data.PosOffset.x, data.PosOffset.y, data.PosOffset.z, data.RotOffset.x, data.RotOffset.y, data.RotOffset.z, true, true, false, false, 0, true);
            attachedObjects[player.id] = object;
            }, 150)
        }
    } catch (e) { } 
});

mp.events.add('detachObject', function (player) {
    try {
        if (player && mp.players.exists(player)) {
            if (attachedObjects[player.id] != undefined) attachedObjects[player.id].destroy();
            attachedObjects[player.id] = undefined;
        }
    } catch (e) { } 
});




// Follow
mp.events.add('setFollow', function (toggle, entity) {
    if (toggle) {
        if (entity && mp.players.exists(entity))
            localplayer.taskFollowToOffsetOf(entity.handle, 0, -1, 0, 1.0, -1, 1.0, true)
    }
    else
        localplayer.clearTasks();
});

mp.events.add('spMode', function (toggle, target) {
    if (toggle) {
        if (target && mp.players.exists(target))
            localplayer.attachTo(target.handle, 0, 1, 1, 2, 0, 0, 0, true, true, false, false, 0, true);
    }
    else
        localplayer.detach(true, false);
});

// CANINE
var canineList = [];
var canineGroup = null; // Relationship group Hash/Int

mp.events.add({
	"create_canine": (id, player, unitType, pos, target) => {
            if (id === null || player === null || unitType === null || pos === null)
                return;

            var dist = mp.game.gameplay.getDistanceBetweenCoords(mp.players.local.position.x,
                                                                 mp.players.local.position.y,
                                                                 mp.players.local.position.z,
                                                                 pos.x,
                                                                 pos.y,
                                                                 pos.z, true);
            let unit = null;
            if (dist <= 350) {
                unit = mp.peds.new(mp.game.joaat(unitType), pos, 270.0, player.dimension);

                unit.freezePosition(false);
                unit.setRelationshipGroupHash(canineGroup);
                unit.setCanBeDamaged(true);
                unit.setInvincible(false);
                unit.setCanRagdoll(true);
                unit.setOnlyDamagedByPlayer(true);
                unit.setCanRagdollFromPlayerImpact(true);
                unit.setSweat(100);
                unit.setRagdollOnCollision(true);

                // Set all abilities and attributes needed for 'taskCombat' to work.
                unit.setCombatAbility(100);
                unit.setCombatRange(1);
                unit.setCombatMovement(0);
                unit.setCombatAttributes(46, true);
                unit.setCombatAttributes(5, true);
                unit.setFleeAttributes(0.0, false);
            }

            var canineUnit = new CanineUnit(id, player, unit, 0, target, pos, unitType);            
            canineList.push(canineUnit);

            if (mp.players.local === player)
                canineUnit.init();
        },

        "delete_canine": (id) => {
            var unit = null;

            unit = canineList.find(x => x.id === id)

            if (unit !== null && unit !== undefined) {
                unit.cleanUp();
                var index = canineList.indexOf(unit);
                if (index > -1) {
                    canineList.splice(index, 1);
                }
            }
        },

        "create_canine_relationship_group": () => {
            canineGroup = mp.game.ped.addRelationshipGroup("CanineGroup", mp.game.joaat("CanineGroup"));
            mp.game.ped.setRelationshipBetweenGroups(5, canineGroup, mp.players.local.getRelationshipGroupHash());
            mp.game.ped.setRelationshipBetweenGroups(5, mp.players.local.getRelationshipGroupHash(), canineGroup);
        },

        "update_canine_position": (id, x, y, z) => {
            const tempUnit = canineList.find(x => x.id === id)
            if (tempUnit !== null && tempUnit !== undefined) {
                // Save pos to variable
                tempUnit.position = new mp.Vector3(x, y, z);

                // Check if new position is within our streaming range
                if (tempUnit.position !== null && tempUnit.position !== undefined) {
                    var dist = mp.game.gameplay.getDistanceBetweenCoords(mp.players.local.position.x,
                                                                         mp.players.local.position.y,
                                                                         mp.players.local.position.z,
                                                                         tempUnit.position.x,
                                                                         tempUnit.position.y,
                                                                         tempUnit.position.z, true);
                    if (dist <= 350) {
                        if (tempUnit.canineHandle === null || tempUnit.canineHandle === undefined) {
                            let unit = mp.peds.new(mp.game.joaat(tempUnit.unitType), tempUnit.position, 270.0, 0);

                            unit.freezePosition(false);
                            unit.setRelationshipGroupHash(canineGroup);
                            unit.setCanBeDamaged(true);
                            unit.setInvincible(false);
                            unit.setCanRagdoll(true);
                            unit.setOnlyDamagedByPlayer(true);
                            unit.setCanRagdollFromPlayerImpact(true);
                            unit.setSweat(100);
                            unit.setRagdollOnCollision(true);

                            // Set all abilities and attributes needed for 'taskCombat' to work.
                            unit.setCombatAbility(100);
                            unit.setCombatRange(1);
                            unit.setCombatMovement(0);
                            unit.setCombatAttributes(46, true);
                            unit.setCombatAttributes(5, true);
                            unit.setFleeAttributes(0.0, false);

                            tempUnit.canineHandle = unit;
                            tempUnit.setState();
                            tempUnit.playAnim();
                        }
                    }
                    // Else if distance is greater than 350, we should delete the entity just before reaching the 500 mark,
                    // or we'll lose control of it. Delete to avoid desync!
                    else {
                        if (tempUnit.canineHandle !== null && tempUnit.canineHandle !== undefined && tempUnit.canineHandle.doesExist()) {
                            tempUnit.canineHandle.destroy();
                            tempUnit.canineHandle = null;
                        }
                    }
                }
            }
        },

        "update_canine_state": (id, state, target) => {
            const tempUnit = canineList.find(x => x.id === id)
            if (tempUnit !== null && tempUnit !== undefined) {
                tempUnit.state = state;
                if (target !== null && target !== undefined)
                    tempUnit.targetHandle = target;
                tempUnit.animInfo = null;
                tempUnit.setState();
            }
        },

        "play_canine_anim": (id, animDict, animName, loop) => {
            const tempUnit = canineList.find(x => x.id === id)
            if (tempUnit !== null && tempUnit !== undefined) {
                if (loop) {
                    // If the anim is set to loop, we'll need to store it,
                    // so players who streamin will also see the anim playing.
                    tempUnit.animInfo = [];
                    tempUnit.animInfo[0] = animDict;
                    tempUnit.animInfo[1] = animName;
                    tempUnit.playAnim();
                }
                // Otherwise just play the anim once for those in range.
                else {
                    if (tempUnit.canineHandle !== null && tempUnit.canineHandle !== undefined && tempUnit.canineHandle.doesExist()) {
                        mp.game.streaming.requestAnimDict(animDict);
                        while (!mp.game.streaming.hasAnimDictLoaded(animDict)) mp.game.wait(0);

                        tempUnit.canineHandle.taskPlayAnim(animDict, animName, 8.0, 0, -1, 0, 0.0, false, false, false);
                    }
                }
            }
        }
});
		
// Canine
class CanineUnit {
    constructor(id, ownerHandle, canineHandle, state, targetHandle, position, unitType) {
        this.id = id;
        this.ownerHandle = ownerHandle;
        this.canineHandle = canineHandle;
        this.state = state;
        this.targetHandle = targetHandle;
        this.posTimer = null;
        this.distTimer = null;
        this.position = position;
        this.unitType = unitType;
        this.animInfo = null;
    }

    init() {
        // Only call init() for the owner of the K-9
        this.posTimer = setInterval(() => {
            this.sendPositionLoop();
        }, 1000);

        this.distTimer = setInterval(() => {
            this.checkDistanceLoop();
        }, 2000);
    }

    sendPositionLoop() {
        if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist()) {
            var coord = this.canineHandle.getCoords(true);
            this.position = coord;
			if (coord != null)
				mp.events.callRemote('update_canine_position', this.ownerHandle, coord.x, coord.y, coord.z);
        }
    }

    checkDistanceLoop() {
        if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist()) {
            // Check if distance is more than streaming range.
            var coords = this.canineHandle.getCoords(true);
            var dist = mp.game.gameplay.getDistanceBetweenCoords(mp.players.local.position.x,
                                                                mp.players.local.position.y,
                                                                mp.players.local.position.z,
                                                                coords.x,
                                                                coords.y,
                                                                coords.z, true);
            if (dist >= 350)
                mp.events.callRemote('force_delete_canine', this.ownerHandle);
        }
    }

    cleanUp() {
        // Clean up everything
        if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
            this.canineHandle.destroy()

        if (this.posTimer !== null && this.posTimer !== undefined)
            clearInterval(this.posTimer);

        if (this.distTimer !== null && this.distTimer !== undefined)
            clearInterval(this.distTimer);
    }

    playAnim() {
        if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
        {
            if (this.animInfo !== null && this.animInfo !== undefined) {
                mp.game.streaming.requestAnimDict(this.animInfo[0]);
                while (!mp.game.streaming.hasAnimDictLoaded(this.animInfo[0])) mp.game.wait(0);

                this.canineHandle.taskPlayAnim(this.animInfo[0], this.animInfo[1], 8.0, 0, -1, 1, 0.0, false, false, false);
            }
        }
    }

    setState() {
        switch (this.state) {
            case 0: // Idle
                if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist()) {
                    this.canineHandle.clearTasksImmediately();
                }
                break;
            case 1: // Follow me
                if (this.ownerHandle !== null && this.ownerHandle !== undefined && mp.players.exists(this.ownerHandle))
                {
                    if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                    {
                        this.canineHandle.clearTasksImmediately();
                        this.canineHandle.taskFollowToOffsetOf(this.ownerHandle.handle, 0, 0, 0, 5, -1, 10.0, true);
                    } 
                }
                break;
            case 2: // Goto me
                if (this.ownerHandle !== null && this.ownerHandle !== undefined && mp.players.exists(this.ownerHandle))
                {
                    if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                    {
                        this.canineHandle.clearTasksImmediately();
                        var pos = this.ownerHandle.position;
                        this.canineHandle.taskGoStraightToCoord(pos.x, pos.y, pos.z, 5, -1, 270, 1.0);
                    }
                }
                break;
            case 3: // Attack
                if (this.targetHandle !== null && this.targetHandle !== undefined && mp.players.exists(this.targetHandle))
                {
                    if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                    {
                        this.canineHandle.clearTasksImmediately();
                        this.canineHandle.taskCombat(this.targetHandle.handle, 0, 16);
                    }
                }
                break;
            case 4: // Tackle
                if (this.targetHandle !== null && this.targetHandle !== undefined && mp.players.exists(this.targetHandle))
                {
                    if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                    {
                        this.canineHandle.clearTasksImmediately();
                        this.canineHandle.taskCombat(this.targetHandle.handle, 0, 16);
                    }
                }
                break;
            case 5: // WanderTrack
                if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                {
                    this.canineHandle.clearTasksImmediately();
                    this.canineHandle.taskWanderInArea(this.position.x, this.position.y, this.position.z, 50, 0, 0);
                    if (this.ownerHandle !== null && this.ownerHandle !== undefined && mp.players.exists(this.ownerHandle))
                    {
                        if (this.ownerHandle === mp.players.local)
                        {
                            setTimeout(() => {
                                mp.events.callRemote('canine_wandertrack_completed');
                            }, 12000);
                        }
                    }
                }
                break;
            case 6: // Track
                if (this.targetHandle !== null && this.targetHandle !== undefined && mp.players.exists(this.targetHandle))
                {
                    if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist())
                    {
                        this.canineHandle.clearTasksImmediately();
                        var pos = this.targetHandle.position;
                        this.canineHandle.taskGoStraightToCoord(pos.x, pos.y, pos.z, 10.0, -1, 270, 1.0);
                    }
                }
                break;
            case 7: // Wander
                if (this.canineHandle !== null && this.canineHandle !== undefined && this.canineHandle.doesExist()) {
                    this.canineHandle.clearTasksImmediately();
                    this.canineHandle.taskWanderInArea(this.position.x, this.position.y, this.position.z, 50, 0, 0);
                }
                break;
            default:
                break;
        }
    }
}
