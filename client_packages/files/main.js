
let weapons =
    [
        ["Pistol", 1467525553, 2],
        ["CombatPistol", 403140669, 2],
        ["SNSPistol", 339962010, 2],
        ["HeavyPistol", 1927398017, 2],
        ["VintagePistol", -1124046276, 2],
        ["APPistol", 905830540, 2],
        ["Revolver", 914615883, 2],
        ["Pistol50", -178484015, 2],
        ["Pistol_mk2", -178484015, 2],

        ["CombatPDW", -1393014804, 1],
        ["MicroSMG", -1056713654, 1],
        ["SMG", -500057996, 1],
        ["MiniSMG", -972823051, 1],
        ["MachinePistol", -331545829, 1],
        ["AssaultSMG", -473574177, 1],

        ["Bat", 32653987, 4],
        
        ["PumpShotgun", 689760839, 3],
        ["HeavyShotgun", -1209868881, 3],
        ["AssaultShotgun", 1255410010, 3],
        ["BullpupShotgun", -1598212834, 3],

        ["CarbineRifle", 1026431720, 3],
        ["AssaultRifle", 273925117, 3],
        ["SpecialCarbine", -1745643757, 3],
        ["MarksmanRifle", -1711248638, 3],

        ["rGlove", 335898267, 6],
        ["lGlove", 335898267, 7]
    ];

let offset = new mp.Vector3(0.1, 0.0, 0.0);
let rotation = new mp.Vector3(0.0, 56.0, 0.0);


for (let weap of weapons) {
    let bone = 0;

    switch (weap[2]) {
        case 0:
            bone = 51826; //"SKEL_R_Thigh";
            offset = new mp.Vector3(0.02, 0.06, 0.1);
            rotation = new mp.Vector3(-100.0, 0.0, 0.0);
            break;
        case 1:
            bone = 58271; //"SKEL_L_Thigh";
            offset = new mp.Vector3(0.08, 0.03, -0.14);
            rotation = new mp.Vector3(-80.77, 0.0, 0.0);
            break;

        case 2:
            bone = 24816; //"SKEL_Spine3";
            offset = new mp.Vector3(-0.08, -0.15, 0.0);
            rotation = new mp.Vector3(180, 155.0, 0.0);
            break;
        case 3:
            bone = 24818; //"SKEL_Spine3";
            offset = new mp.Vector3(-0.0, -0.155, -0.05); // x =(-)Paeen Badan    y=(-) Posht    z= (+) Rast Badan
            rotation = new mp.Vector3(180, 155.5, 0.0); // x=(-)Charkhesh Be Chap    y=(+)Chap Charkhesh(Dayere)    z=(+)Charkhesh Jolo
            break;
        case 5:
            bone = 24818; //"SKEL_Spine3";
            offset = new mp.Vector3(-0.08, -0.15, -0.05);
            rotation = new mp.Vector3(180, 145.0, 0.0);
            break;
        case 4:
            bone = 58271; //"SKEL_Spine3";
            offset = new mp.Vector3(0.08, 0.03, -0.14); // x =(-)Paeen Badan    y=(-) Posht    z= (-) Rast Badan
            rotation = new mp.Vector3(-80.77, 0.0, -90.0); // x=(-)Charkhesh Be Chap    y=(+)Chap Charkhesh(Dayere)    z=(+)Charkhesh Jolo
            break;
        case 6:
            bone = 6286; //"SKEL_Spine3";
            offset = new mp.Vector3(-0.1, 0.0, -0.025); // x =(+)Paeen Badan    y=(-) Posht    z= (+) Rast Badan
            rotation = new mp.Vector3(90.0, -20.0, 90.0); // x=(-)Charkhesh Be Chap    y=(+)Chap Charkhesh(Dayere)    z=(+)Charkhesh Jolo
            break;
        case 7:
            bone = 18905; //"SKEL_Spine3";
            offset = new mp.Vector3(-0.05, 0.0, 0.04); // x =(+)Paeen Badan    y=(-) Posht    z= (+) Rast Badan
            rotation = new mp.Vector3(90.0, -160.0, 90.0); // x=(-)Charkhesh Be Chap    y=(+)Chap Charkhesh(Dayere)    z=(+)Charkhesh Jolo
            break;
        default:
            break;
    }
        mp.attachmentMngr.register(weap[0], weap[1], bone, offset, rotation);
}

mp.attachmentMngr.register("garbage_job", "prop_rub_binbag_01", 28422, new mp.Vector3(0, 0.05, -0.04), new mp.Vector3(0, 8, 0));
mp.attachmentMngr.register("fish_rod", "prop_fishing_rod_01", 60309, new mp.Vector3(-0.01, -0.01, 0.07), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Mine", "prop_tool_jackham", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));

mp.attachmentMngr.register("Drink_Cola", "prop_ecola_can", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Drink_Sprunk", "prop_orang_can_01", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Drink_coffee", "ng_proc_coffee_01a", 60309, new mp.Vector3(-0.04, 0, -0.02), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Drink_Water", "prop_ld_flow_bottle", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Drink_wine_red", "prop_wine_red", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Throwmoney", "prop_cash_pile_01", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Drink_Beer", "prop_beer_blr", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Drink_Whiskey", "prop_whiskey_bottle", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Drink_Votka", "p_whiskey_notop", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Drink_konjak", "prop_drink_whisky", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Drink_samp", "prop_drink_champ", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));

mp.attachmentMngr.register("Eat_Burger", "prop_cs_burger_01", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Eat_sandwich", "prop_sandwich_01", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("Eat_hotdog", "prop_cs_hotdog_01", 60309, new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0));

mp.attachmentMngr.register("watering_can", "prop_wateringcan", 28422, new mp.Vector3(0, +0.1, +0.1), new mp.Vector3(-80, 0, -180));

mp.attachmentMngr.register("cuff", "p_cs_cuffs_02_s", 6286, new mp.Vector3(-0.05, 0.08, 0), new mp.Vector3(-90, 0, -90));
mp.attachmentMngr.register("wheatbox", "prop_feed_sack_01", 28422, new mp.Vector3(0.0, -0.15, -0.18), new mp.Vector3(0, 0, 0));
mp.attachmentMngr.register("teg", "prop_barbell_20kg", 28422, new mp.Vector3(0.0, 0.0, 0.0), new mp.Vector3(0, 0, 0));


mp.game.audio.startAudioScene("FBI_HEIST_H5_MUTE_AMBIENCE_SCENE");

mp.game.invoke(0xB4F90FAF7670B16F, false); //police reports
mp.game.invoke(0x218DD44AAAC964FF, "AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_GENERAL", true, 0);
mp.game.invoke(0x218DD44AAAC964FF, "AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_WARNING", true, 0);
mp.game.invoke(0x218DD44AAAC964FF, "AZ_COUNTRYSIDE_PRISON_01_ANNOUNCER_ALARM", true, 0);
mp.game.invoke(0xBDA07E5950085E46, 0, false, false);
mp.game.invoke(0x1D6650420CEC9D3B, "AZ_DISTANT_SASQUATCH", 0, 0);

mp.game.audio.setAudioFlag("LoadMPData", true);
mp.game.audio.setAudioFlag("DisableFlightMusic", true);

let CarryItem = false;
const controlsToDisable = [12, 13, 14, 15, 16, 17, 22, 23, 24, 25, 37, 44, 45, 47, 55, 58, 69, 70, 92, 114, 140, 141, 142, 143, 257, 263, 264, 331];

let adminrank = ['Support', 'Senior Support', 'Moderator', 'Senior Moderator', 'Administrator', 'Senior Administrator', 'Head Administrator', 'Developer', 'Founder'];


global.chatopened = false;
global.isChat = false;
global.logged = 0;

mp.game.interior.enableInteriorProp(mp.game.interior.getInteriorAtCoordsWithType(-38.62, -1099.01, 27.31, 'v_carshowroom'), 'csr_beforeMission');

mp.game.interior.enableInteriorProp(mp.game.interior.getInteriorAtCoordsWithType(-38.62, -1099.01, 27.31, 'v_carshowroom'), 'csr_beforeMission');
//mp.game.interior.enableInteriorProp(mp.game.interior.getInteriorAtCoordsWithType(-38.62, -1099.01, 27.31, 'v_carshowroom'), 'shutter_closed');

mp.game.controls.useDefaultVehicleEntering = false;

const controls = mp.game.controls;
	
controls.disableControlAction(0, 58, true);
controls.disableControlAction(0, 23, true);


mp.game.vehicle.defaultEngineBehaviour = false;


let phone = undefined,
    incomingCaller = null,
    dialInterval = null,
    phoneNumber = 0;

let phone_menu = false;
phone_msg = false;
phone_app = false;
phone_app_loaded = false;
atm_close = true;


let ringTone = null,
    ringToneCounter = 0;



//
// CHAT UI
//


const localPlayer = mp.players.local;
var signal1, signal2;

var screenRes = mp.game.graphics.getScreenActiveResolution(0, 0);

mp.gui.chat.show(false); //Disables default RageMP Chat

mp.gui.chat.safeMode = false;

let chat = mp.browsers.new('package://files/chat/index.html');

chat.markAsChat();


var resolution = mp.game.graphics.getScreenResolution(0, 0);


global.lastCheck = 0;



var res_X = 1920; //API.getScreenResolutionMaintainRatio().Width;
var res_Y = 1080; //API.getScreenResolutionMaintainRatio().Height;

/* Speed Limiter */
var limitMenu = null;
var limitSpeedItem = null;
var limitToggleItem = null;

var limitMultiplier = 5;

var vehicleMaxSpeed = {};
var vehicleMaxSpeedEnabled = {};

var blockedModels = [782665360, -1860900134]; // people can't speed limit these vehicles (rhino and insurgent for example)
var blockedCategories = [14, 15, 16]; // people can't speed limit vehicles that belong these categories - https://wiki.gt-mp.net/index.php?title=Vehicle_Classes
//

let jail_time = 0;

/* NativeUI */
const NativeUI = require("files/nativeui");
const Menu = NativeUI.Menu;
const UIMenuItem = NativeUI.UIMenuItem;
const UIMenuListItem = NativeUI.UIMenuListItem;
const UIMenuCheckboxItem = NativeUI.UIMenuCheckboxItem;
const BadgeStyle = NativeUI.BadgeStyle;
const Point = NativeUI.Point;
const ItemsCollection = NativeUI.ItemsCollection;
const Color = NativeUI.Color;

var cam;


const camerasManager = require('./files/camerasManager.js');

var menu_libary = false;
//Menus

//isAdminMenu


var markers = {};
var blips = {};
var Textlabel = {};

class JobHelper {
    static createMarker(name, position, radius) {
        try {

        
        if (markers[name] != null) {
            return;
        }
        var marker = mp.markers.new(28, position, radius, {
            direction: new mp.Vector3(0, 0, 0),
            rotation: new mp.Vector3(0, 0, 0),
            color: [255, 0, 0, 100],
            visible: true,
            dimension: 0
        });
        markers[name] = marker;
            return marker;
        } catch (e) {
            mp.events.callRemote("Client_Error", "CreateMarker: " + e);
        }
    }
    static removeMarker(name) {
        try {

        
        if (markers.length == 0 || markers[name] == null) {
            return;
        }
        markers[name].destroy(); // Needs testing, should replace deleteEntity
        markers[name] = null;
        } catch (e) {
            mp.events.callRemote("Client_Error", "RemoveMarker Job: " + e);
        }
    }

    static createlabel(name, text, position, drawDistance, color) {
        if (Textlabel[name] != null) {
            return;
        }
        var marker = mp.labels.new(text, position,
        {
                los: false,
                font: 6,
                drawDistance: drawDistance,
                color: color,
                dimension: localPlayer.dimension
        });
        Textlabel[name] = marker;
        return marker;
    }
    static Editlabel(name,text) {
        if (Textlabel.length == 0 || Textlabel[name] == null) {
            return;
        }
        Textlabel[name].text = text; // Needs testing, should replace deleteEntity
    }
    static removelabel(name) {
        if (Textlabel.length == 0 || Textlabel[name] == null) {
            return;
        }
        Textlabel[name].destroy(); // Needs testing, should replace deleteEntity
        Textlabel[name] = null;
    }

    static createBlip(name, position, color) {
        try {

     
        if (blips[name] != null) {
            return blips[name];
        }
        let blip = mp.blips.new(1, position, {
            name: name,
            color: color,
            shortRange: false,
        });
        blips[name] = blip;
        return blip;
           } catch (e) {
            mp.events.callRemote("Client_Error", "CreateBlip Job: " + e);
        }
    }
    static removeBlip(name) {
        try {

       
        if (blips.length == 0 || blips[name] === null || blips[name] === undefined) {
            return;
        }
        blips[name].destroy();
            blips[name] = null;
        } catch (e) {
            mp.events.callRemote("Client_Error", "RemoveBlip Job: " + e);
        }
    }
}


class MarkerHelper {
    static createMarker(name, position, radius) {
        try {

        
        if (markers[name] != null) {
            return;
        }
        var marker = mp.markers.new(1, position, radius, {
            direction: new mp.Vector3(0, 0, 0),
            rotation: new mp.Vector3(0, 0, 0),
            color: [255, 0, 0, 100],
            visible: true,
            dimension: 0
        });
        markers[name] = marker;
        return marker;
        } catch (e) {
            mp.events.callRemote("Client_Error", "CreateMarker#2: " + e);
        }
    }
    static removeMarker(name) {
        try {

        
        if (markers.length == 0 || markers[name] == null) {
            return;
        }
        markers[name].destroy(); // Needs testing, should replace deleteEntity
        markers[name] = null;
        } catch (e) {
            mp.events.callRemote("Client_Error", "RemoveMarker#2: " + e);
        }
    }
}

class BlipHelper {
    static createBlip(name, position, color) {
        try {

        
        if (blips.length != 0 && blips[name] !== undefined && blips[name] !== null) {
            blips[name].destroy();
            blips[name] = null;
        }
        
        var blip = mp.blips.new(1, position, {
            name: name,
            color: color,

            shortRange: false,
        });
        blips[name] = blip;
            return blip;
        } catch (e) {
            mp.events.callRemote("Client_Error", "CreateBlip#2: " + e);
        }
    }
    static createBlipExt(name, position, color, size, sprite = 0, shortRange = false, bname = null) {
        try {

        
        if (blips.length != 0 && blips[name] !== undefined && blips[name] !== null) {
            blips[name].destroy();
            blips[name] = null;
        }
        var blip;

        if (bname == null) {
            blip = mp.blips.new(1, position, {
                //name: name,
                color: color,
                scale: size,
                shortRange: false,
            });
        } else {
            blip = mp.blips.new(1, position, {
                name: bname,
                color: color,
                scale: size,
                shortRange: false,
            });
        }

        blips[name] = blip;
        blips[name].setColour(color);
        blips[name].setAsShortRange(shortRange);
        blips[name].setScale(size);


        if (sprite != 0) blips[name].setSprite(sprite);
            return blip;
        } catch (e) {
            mp.events.callRemote("Client_Error", "CreateBlipEx: " + e);
        }
    }

    static removeBlip(name) {
        try {

        
        if (blips.length != 0 && blips[name] !== undefined && blips[name] !== null) {
            blips[name].destroy();
            blips[name] = null;
            }
        } catch (e) {
            mp.events.callRemote("Client_Error", "RemoveBlip#3: " + e);
        }

    }

    static moveBlip(name, position) {
        try {

        
        if (blips[name] == null) {
            return;
        }
        blips[name].setCoords(position);
        } catch (e) {
            mp.events.callRemote("Client_Error", "MoveBlip: " + e);
        }
    }

    static colorBlip(name, color) {
        try {

        
        if (blips[name] == null) {
            return;
        }
        blips[name].setColour(color);
        } catch (e) {
            mp.events.callRemote("Client_Error", "ColorBlip: " + e);
        }
    }

    static SetRoute(name, enabled) {
        try {

        
        if (blips[name] == null) {
            return;
        }
        blips[name].setRoute(enabled);
        } catch (e) {
            mp.events.callRemote("Client_Error", "SetRoute: " + e);
        }
    }
}

mp.events.add("GetNearestObject", () => {
    getNearestObjects()
});

function getNearestObjects() {

    var tempO = null;
    var objects = mp.objects.toArray();
    objects.forEach(
        (object) => {
            var posL = localPlayer.position;
            var posO = object.position;
            var distance = mp.game.gameplay.getDistanceBetweenCoords(posL.x, posL.y, posL.z, posO.x, posO.y, posO.z, true);
            if (object.getVariable('TYPE') != undefined && localPlayer.dimension === object.dimension && distance < 3) {
                if (tempO === null) tempO = object;
                else if (mp.game.gameplay.getDistanceBetweenCoords(posL.x, posL.y, posL.z, posO.x, posO.y, posO.z, true) <
                    mp.game.gameplay.getDistanceBetweenCoords(posL.x, posL.y, posL.z, tempO.position.x, tempO.position.y, tempO.position.z, true))
                    tempO = object;
            }
        });
    mp.gui.chat.push("object: " + tempO);
}

global.uiPlayer_Browsers = undefined;
global.uiGeneralStart_Browsers = undefined;
let uiGlobal_Browsers = undefined;
let Tuning_Browsers = undefined;
let autoshopbrowser = undefined;
let LockPick_Browser = undefined;
let uiProgressBar_Browsers = undefined;
let uiGlobal_Notifiaction = undefined;
let uiVelo_Browsers = undefined;

let uiDeathScreen = undefined;



let currentMoney = null;
let currentBank = null;

let currentHunger = 0;
let currentThirsty = 0;

function updateDirectionText() {
    var camera = mp.cameras.new("gameplay");
    var cameraDirection = camera.getDirection();

    if (0.3 < cameraDirection.x && 0.3 < cameraDirection.y) {
        text = "N";
    } else if (cameraDirection.x < -0.3 && 0.3 < cameraDirection.y) {
        text = "N";
    } else if (0.3 < cameraDirection.x && cameraDirection.y < -0.3) {
        text = "S";
    } else if (cameraDirection.x < -0.3 && cameraDirection.y < -0.3) {
        text = "S";
    } else if (-0.3 < cameraDirection.x && cameraDirection.x < 0.3 && cameraDirection.y < -0.3) {
        text = "S";
    } else if (cameraDirection.x < -0.3 && -0.3 < cameraDirection.y && cameraDirection.y < 0.3) {
        text = "W";
    } else if (0.3 < cameraDirection.x && -0.3 < cameraDirection.y && cameraDirection.y < 0.3) {
        text = "E";
    } else if (-0.3 < cameraDirection.x && cameraDirection.x < 0.3 && cameraDirection.y > 0.3) {
        text = "N";
    }
    camera.destroy(true);
}

function playerEnterVehicleHandler(vehicle, seat) {
    mp.players.local.setHelmet(false);
}

mp.events.add("playerEnterVehicle", playerEnterVehicleHandler);




var newCam = null;


var selectCharacter = camerasManager.createCamera('selectCharacter', 'default', new mp.Vector3(-533.1306, -224.914, 38.64975), new mp.Vector3(-10, 0, 2), 50);

var school_checkpoint = null;



let clicked = false;

let biz = undefined;
mp.events.add({


    "menu_libary": (toggles) => {
        menu_libary = toggles;
		
		if(toggles === false) mp.events.callRemote('animationMenuVariableOff');
    },

    "factionCharacterKick": (id,rank) => {
        mp.events.callRemote("factionCharacterKick", id,rank);
    },
    "factionJoin": (id) => {
        mp.events.callRemote("factionJoin", id);
    },
    "factionJoinDecline": (id) => {
        mp.events.callRemote("factionJoinDecline", id);
    },
    "factionJoinApprove": (id) => {
        mp.events.callRemote("factionJoinApprove", id);
    },
    "factionDecline": () => {
        mp.events.callRemote("factionDecline");
    },
    "factionLeave": (id) => {
        mp.events.callRemote("factionLeave", id);
    },
    "ShowFactionList": (inventoryJson, leader, member, invite) => {
        if (uiGlobal_Browsers == undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/faction/FactionsList.html");
            uiGlobal_Browsers.execute("populateFactionsList('" + inventoryJson + "','" + leader + "','" + member + "','" + invite + "')");
        }

    },
    "showfactionmenu": (factionInfo, requestsList, membersList, ranksList) => {
        if (uiGlobal_Browsers == undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/faction/FactionsMenu.html");
            uiGlobal_Browsers.execute("populateFactionMenu('" + factionInfo + "','" + requestsList + "','" + membersList + "','" + ranksList + "')");
        }
    },
    "closeFactions": () => {
        uiGlobal_Browsers.destroy();
        uiGlobal_Browsers = undefined;
    },
    "createFaction": (name, type) => {

        mp.events.callRemote("createFaction", name);
        uiGlobal_Browsers.destroy();
        uiGlobal_Browsers = undefined;
    },
    "EditCharacterRank": (characterid, newrank) => {

        mp.events.callRemote("EditCharacterRank", characterid, newrank);
    },
    "EditRankName": (rankid, rankname) => {

        mp.events.callRemote("EditRankName", rankid, rankname);
    },



    "addLocal": (attachmentId) => {
       mp.attachmentMngr.addLocal(attachmentId);
    },
	"removeLocal": (attachmentId) => {
       mp.attachmentMngr.removeLocal(attachmentId);
    },
	
	"Send_ToServer": (message) => {
        mp.events.callRemote('ServerChat', message);
    },
	
    "Send_ToChat": (time, name, text) => {

        if (name == undefined)
        {
            name = '';
        }
        if (text == undefined) {
            text = '';
        }

        let args = [name + "<span style='opacity:0; margin-left:-2px;'>a</span>", text];
        
        mp.gui.chat.push(name + "<span style='opacity:0; margin-left:-2px;'>a</span>" + text);
 

    },

    "openChat": () => {
        if (global.chatopened) return false;
        toggleChat(true);
        global.chatopened = true;
    },
    "closeChat": () => {
        if (!global.chatopened) return false;
        chat.execute("sendMsg();");

        toggleChat(false);
        global.chatopened = false;
    },
    "forceCloseChat": () => {
        if (!global.chatopened) return false;
        toggleChat(false);
        global.chatopened = false;
    },
    "getPreviousMessage": () => {
        if (!global.chatopened) return false;

        chat.execute("previous();");
    },
    "getNextMessage": () => {
        if (!global.chatopened) return false;

        chat.execute("next();");
    },


    "CreateRaceCheckpoint": (position, direction) => {

        school_checkpoint = mp.checkpoints.new(0, position, 6.0, {
            direction: direction,
            color: [247, 221, 52, 150],
            visible: true,
            dimension: 0
        });

        BlipHelper.createBlipExt("race_checkpoint", position, 81, 1.0, 0, false);
        BlipHelper.createBlipExt("race_checkpoint_2", direction, 81, 0.5, 0, false);
        BlipHelper.colorBlip("race_checkpoint", 81);
        BlipHelper.colorBlip("race_checkpoint_2", 81);

    },
	
	

    "DeleteRaceCheckpoint": () => {
        if (school_checkpoint != null) {
            school_checkpoint.destroy();
            school_checkpoint = null;
        }

        BlipHelper.removeBlip("race_checkpoint");
        BlipHelper.removeBlip("race_checkpoint_2");
    },

    "marker_create": (name, position, radius) => {
        MarkerHelper.createMarker(name, position, radius);
    },
    "KEY_ARROW_UP": () => {
        if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

        mp.events.callRemote('keypress:ARROW_UP');
    },
    "delete_marker": (name) => {
        MarkerHelper.removeMarker(name);
    },
    "NewTeleportMenu": (title,data) => {
        if (uiPlayer_Browsers != undefined) {
            uiPlayer_Browsers.execute("LoadList(" + title + "," + data + ")");
        }
    },
    "NewMenuSelected": (id,name) => {
        mp.events.callRemote("NewMenuSelected",id,name);
    },
    "KEY_ARROW_UP": () => {
        if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

        mp.events.callRemote('keypress:ARROW_UP');
    },

    "blip_create": (name, position, color) => {
        BlipHelper.createBlip(name, position, color);
    },

    "blip_create_ext": (name, position, color, size, sprite = 0, range = false, bname = null) => {
        BlipHelper.createBlipExt(name, position, color, size, sprite, range, bname);
        BlipHelper.colorBlip(name, color);
    },

    "blip_remove": (name) => {
        BlipHelper.removeBlip(name);
    },
    
    "blip_move": (name, position) => {
        BlipHelper.moveBlip(name, position);
    },

    "blip_color": (name, color) => {
        BlipHelper.colorBlip(name, color);
    },

    "blip_router_visible": (name, enabled) => {
        BlipHelper.SetRoute(name, enabled);
    },

    "gps_set_loc": (nearestX, nearestY) => {
        mp.game.ui.setNewWaypoint(nearestX, nearestY);
    },

    "show_radar": () => {
        mp.game.ui.displayRadar(true);
    },

    "hide_radar": () => {
        mp.game.ui.displayRadar(false);
    },
    "job_create_label": (name, text, position, drawDistance, color) => {
        JobHelper.createlabel(name, text, position, drawDistance, color);
    },
    "job_remove_label": (name) => {
        JobHelper.removelabel(name);
    },
    "job_edit_label": (name, text) => {
        JobHelper.Editlabel(name, text);
    },

    "job_create_marker": (name, position) => {
        var jobName = name;
        var vector = position;
        JobHelper.createMarker(jobName, vector, 1);
    },

    "job_create_blipped_marker": (name, jPosition) => {
        var jobName = name;
        var vector = jPosition;
        JobHelper.createMarker(jobName, vector, 1);
        JobHelper.createBlip(jobName, vector, 1);
    },

    "create_house_blip": (name, hPosition) => {
        var houseName = name;
        var position = hPosition;
        var blip = mp.blips.new(40, position, {
            name: houseName,
            color: 2,
            shortRange: true,
        });
        blips[houseName] = blip;
    },

    "create_garage_blip": (name, hPosition) => {
        var houseName = name;
        var position = hPosition;
        var blip = mp.blips.new(50, position, {
            name: houseName,
            color: 31,
            shortRange: true,
        });
        blips[houseName] = blip;
    },

    "create_faction_house_blip": (name, hPosition) => {
        var houseName = name;
        var position = hPosition;
        var blip = mp.blips.new(40, position, {
            name: houseName,
            color: 31,
            shortRange: true,
        });
    },

    "create_rent_blip": (name, hPosition) => {
        var houseName = name;
        var position = hPosition;
        var blip = mp.blips.new(40, position, {
            name: houseName,
            color: 28,
            shortRange: true,
        });
        blips[houseName] = blip;
    },

    "job_remove_marker": (name) => {
        var jobName = name;
        JobHelper.removeMarker(jobName);
        JobHelper.removeBlip(jobName);
    },

    "job_create_pickup": (jId, jPosition, jRadius) => {
        var id = jId;
        var position = jPosition;
        var radius = jRadius;
        JobHelper.createBlip(jId, jPosition, 0);
        JobHelper.createMarker(jId, jPosition, jRadius);
    },

    "job_create_pickup": () => {
        if (blips.length == 0 && markers.length == 0)
            return;
        for (var key in blips) {
            JobHelper.removeBlip(key);
        }
        for (var key in markers) {
            JobHelper.removeMarker(key);
        }
    },

    "getgroundz": () => {
        mp.gui.chat.push("Ground Z: ~r~" + mp.game.gameplay.getGroundZFor3dCoord(localPlayer.position.x, localPlayer.position.y, localPlayer.position.z, 0.0, false));
    },
    "MesToChat": (msg) => {
        mp.gui.chat.push(msg);
    },

    "job_remove_pickup": (jName) => {
        var name = jName;
        JobHelper.removeBlip(jName);
        JobHelper.removeMarker(jName);
    },

    "job_create_blip": (jName, jPosition, jColor) => {
        var name = jName;
        var position = jPosition;
        var color = jColor;
        JobHelper.createBlip(jName, jPosition, parseInt(jColor));
    },

    "job_remove_blip": (jName) => {
        var name = jName;
        JobHelper.removeBlip(jName);
    },

    "get_waypoint_pos": () => {
        var pos = getWaypointPos();

        setTimeout(() => {
            pos.z = mp.game.gameplay.getGroundZFor3dCoord(pos.x, pos.y, 9999, 9999, false);
            mp.events.callRemote('OnPlayerCreateWaypoint', pos.x, pos.y, pos.z);
        }, 1500);
    },

    "cef_show_name_creater": () => {
        mp.events.call('destroyBrowser');
        mp.events.call('createBrowser', ['package://files/auth/dialog.html']);
    },

    "onSubmitGeneric": (string) => {
        onSubmitGeneric(string);
    },

    "reset_camera": () => {
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
        if (newCam != null) newCam.setActive(false);
    },

    "play_sound": (soundName, soundSetName) => {
        if (soundName === null || soundSetName === null) return;
        mp.game.audio.playSoundFrontend(-1, soundName, soundSetName, true);
    },


    "createCustomCamera": (cameraOne, cameraTwo) => {

    },

    "DestroyCamera": () => {
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
        newCam.setActive(false);
    },

    "JailTime": (time) => {
        jail_time = time;
    },
    //
    "logged": () => {
        logged = 1;
        mp.players.local.setHelmet(false);


        camerasManager.destroyCamera(selectCharacter);
        camerasManager.setActiveCamera(selectCharacter, false);
        mp.game.cam.renderScriptCams(false, false, 0, true, false);

    },
	
	"showChat": () => {

        mp.gui.chat.activate(true);
        mp.gui.chat.show(true);


    },
   

    "TimeOfDay": (time_text) => {
        DAYNIGHT_TEXT = time_text;
        if (phone != undefined) {
            phone.execute("UpdateTime('" + time_text + "');");
        }
        if (uiVelo_Browsers != undefined) {
            var d = new Date();
            let month = d.getMonth() + 1;
            let date = d.getDate() + "." + month + "." + "" + d.getFullYear();
            uiVelo_Browsers.execute("updateclock('" + time_text + "','" + localPlayer.remoteId + "','" + date+"')");
          }
    },
    "remote_back": (essm) => {
        mp.events.callRemote('pSelected', essm);
    },
    "CarryItem": (bol) => {
        CarryItem = bol;
    },
    "update_money_display": (money, bank) => {
        currentMoney = money;
        currentBank = bank;

        if (uiVelo_Browsers != undefined) {
            uiVelo_Browsers.execute("SetPlayerMoney('" + currentMoney + "', '" + currentBank + "')");
        }
        mp.game.invoke('0x96DEC8D5430208B7', false);
    },
    

    "update_hunger_display": (hunger, thirsty) => {
        currentHunger = hunger;
        currentThirsty = thirsty;

        if (uiPlayer_Browsers != undefined) {
            uiPlayer_Browsers.execute("SetPlayerFood(" + currentHunger + ", " + currentThirsty + ")");
           
        }
    },

    "update_health": (health,armor) => {
        if (uiPlayer_Browsers != undefined) {
         //   uiPlayer_Browsers.execute("SetPlayerHealth(" + health + ")");
            uiPlayer_Browsers.execute('SetPlayerHealth("' + localPlayer.getHealth() + '", "' + localPlayer.getArmour() + '")');
            
        }
    },

    "update_armor": (armor) => {
        if (uiPlayer_Browsers != undefined) {
            uiPlayer_Browsers.execute("SetPlayerArmor(" + armor + ")");
        }
    },

    "toggle_player_hud": (stats) => {
        if (uiPlayer_Browsers != undefined) {
            uiPlayer_Browsers.execute("DisplayMenu(" + stats + ")");
            uiVelo_Browsers.execute("DisplayMenu(" + stats + ")");
        }
    },

    "chatnotf": (string) => {

        mp.events.callRemote('chatnotf',string);

    },

    
    "show_player_hud": (ui_enable) => {

        if (ui_enable === true) {
            if (uiPlayer_Browsers === undefined) {
                uiPlayer_Browsers = mp.browsers.new("package://files/new_hud/index.html");
            }
            
            if (uiVelo_Browsers === undefined) {
                uiVelo_Browsers = mp.browsers.new("package://files/new_hud/money.html");
                uiVelo_Browsers.execute("DisplayMenu(true)");
                uiVelo_Browsers.execute("DisplayMoney(true)");
                uiVelo_Browsers.execute("DisplayVeh(false)");
            }
            uiVelo_Browsers.execute("SetPlayerMoney(" + currentMoney + ", " + currentBank + ")");

            
        } else {
            if (uiPlayer_Browsers != undefined) {
                uiPlayer_Browsers.Destroy();
                uiPlayer_Browsers = undefined;
            }
            if (uiVelo_Browsers != undefined) {
                uiVelo_Browsers.Destroy();
                uiVelo_Browsers = undefined;
            }
        }
    },

    "displaySubtitle": (message_text, time) => {

        mp.game.ui.setTextEntry2("STRING");
        mp.game.ui.addTextComponentItemString(message_text);
        mp.game.ui.drawSubtitleTimed(time, 1);
    },

    "DisplayCustomCamera": (position, target, fov = 60) => {
        newCam = mp.cameras.new('default', position, target, fov);
        newCam.setCoord(position.x, position.y, position.z);
        newCam.pointAtCoord(position.x, position.y, position.z);
        newCam.setFov(fov);

        newCam.setActive(true);
        mp.game.cam.renderScriptCams(true, false, 0, true, false);
    },

    "DestroyCustomCamera": () => {
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
        newCam.setActive(false);
    },

    "playAnimation": (dict, state, flag) => {
        mp.events.callRemote('PlayAnimationFromMenu', dict, state, flag);
    },

    "stopAnimation": () => {
        mp.events.callRemote('StopAnimationFromMenu');
    },

    "closeAnimationMenu": () => {
        mp.events.call('Destroy_Character_Menu');
        mp.events.callRemote('closeAnimationMenu');
    },
    "setAnimationShortcut": (e, category, t) => {
        mp.gui.chat.push('setAnimationShortcut(' + e + ', ' + category + ', ' + t + ')');
    },

    "Display_Animation": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/animation/animation.html");
        }

        mp.gui.cursor.visible = true;
    },

    "InjuredSystem": (time) => {
		mp.game.graphics.startScreenEffect("DeathFailMPIn", 0, true);
		mp.game.cam.setCamEffect(1);

    },
	
	"InjuredSystem:Destroy": () => {

		mp.game.graphics.stopScreenEffect("DeathFailMPIn");
		mp.game.cam.setCamEffect(0);
    },
	
    "InjuredSystem:Respawn": () => {
        if (uiDeathScreen != undefined) {
            uiDeathScreen.destroy();
			uiDeathScreen = undefined;
        }
		
		mp.events.callRemote("InjuredSystemHospital", 3 * 60);
    },
	
    "Display_Release_Vehicles": (vehicle_list) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/vehicles/vehicle_release.html");
        }

        uiGlobal_Browsers.execute("LoadPlayerVehiclesToRelease('" + vehicle_list + "');");
        mp.gui.cursor.visible = true;
    },

    "Player_Vehicle_Release": (index, price) => {
        mp.events.callRemote("PayInsure", index, price);
    },
	
	"LoadWhiteList": (data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/whitelist/whitelist_manage.html");
        }

        uiGlobal_Browsers.execute("LoadWhiteList('" + data + "');");
        mp.gui.cursor.visible = true;
    },

    "Display_Player_Vehicles": (vehicle_list) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/vehicles/vehicle_list.html");
        }

        uiGlobal_Browsers.execute("LoadPlayerVehicles('" + vehicle_list + "');");
        mp.gui.cursor.visible = true;
    },

    "Display_Wanted_List": (wanted_list) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/vehicles/wanted.html");
        }

        uiGlobal_Browsers.execute("LoadWantedList('" + wanted_list + "');");
        mp.gui.cursor.visible = true;
    },

    "Player_Whitelist_Aprove": (index) => {
        mp.events.callRemote("Player_Whitelist_Aprove", index);
    },

    "Player_Whitelist_Remove": (index) => {
        mp.events.callRemote("Player_Whitelist_Remove", index);
    },
	
    "Player_Vehicle_Track": (index) => {
        mp.events.callRemote("TrackVehicle", index);
    },

    "Player_Vehicle_Destroy": (index) => {
        mp.events.callRemote("DeleteVehicle", index);
    },

    "trackplayer": (index) => {
        mp.events.callRemote("locateplayer", index);
    },

    "ShowHouseExitMenu": (id,ownername, gslot) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/house/buy.html");
        }
        uiGlobal_Browsers.execute("Loadmenu('" + id + "','" + ownername + "', '" + gslot + "');");
        mp.gui.cursor.visible = true;
    },
    "ShowHouseBuyMenu": (id, price, gslot) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/house/check.html");
        }
        uiGlobal_Browsers.execute("Loadmenu('" + id + "','" + price + "', '" + gslot + "');");
        mp.gui.cursor.visible = true;
    },
    "HouseControlPanel": (index) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/house/control.html");
        }
        uiGlobal_Browsers.execute("loaddata('" + index + "');");
        mp.gui.cursor.visible = true;
    },

    "lockhouse": (index) => {
        mp.events.callRemote("house_lockhouse", index);
    },
    "fastsale": (index) => {
        mp.events.callRemote("house_fastsale", index);
    },
    "selltoplayer": (index) => {
        mp.events.callRemote("house_selltoplayer", index);
    },
    "furniture": (index) => {
        uiGlobal_Browsers.destroy();
        uiGlobal_Browsers = undefined;
        mp.events.callRemote("house_furniture", index);
    },
    "showfurnitureshop": (businessItemsJson,returnto) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/house/furniture.html");
        }
        uiGlobal_Browsers.execute("populateBusinessItems('" + businessItemsJson + "','Furniture Shop','" + returnto+"','1');");
        mp.gui.cursor.visible = true;
    },

    "purchasefurniture": (returnto, selectedname, selected) => {
        mp.events.callRemote(returnto, selectedname, selected);
    },
    


    "ExitFromHouse": (id) => {
        mp.events.callRemote("ExitFromHouse", id);
    },
    "InspectHouse": (id) => {
        mp.events.callRemote("InspectHouse", id);
    },
    "BuyHouse": (id) => {
        mp.events.callRemote("BuyHouse", id);
    },

    "BuyHighEnd": (id) => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
            mp.events.callRemote("BuyHighEnd", id);
        }
        freezeMe = false;
        mp.gui.cursor.visible = false;
    },

    "TakeOutVehicle": (id) => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
            mp.events.callRemote("TakeOutVehicle", id);
        }
        freezeMe = false;
        mp.gui.cursor.visible = false;
    },

    "UpdateVehicleInfo": (vehname) => {
        if (uiGlobal_Browsers != undefined) {

            let hash = undefined;
             hash = mp.game.joaat(vehname);
            if (hash == undefined) {
                uiGlobal_Browsers.execute("updateVehicleInfo('0','0','0','0','0');");

            } else {
                uiGlobal_Browsers.execute("updateVehicleInfo('" + mp.game.vehicle.getVehicleModelMaxBraking(hash) + "','" + mp.game.vehicle.getVehicleModelAcceleration(hash) + "','" + (mp.game.vehicle.getVehicleModelMaxSpeed(hash) * 3.6) + "','" + mp.game.vehicle.getVehicleModelMaxNumberOfPassengers(hash) + "','" + mp.game.vehicle.getVehicleModelMaxTraction(hash) + "');");
            }
        }

    },
	
    "Exit_Tuning": () => {
        mp.gui.cursor.visible = false;
        mp.events.call("hidePoliceCivilMenu");
        mp.events.callRemote("Hide_LSCustom");

    },
    "Display_Tunning_home": () => {
        mp.events.call("hidePoliceCivilMenu");
        if (Tuning_Browsers === undefined) {
            Tuning_Browsers = mp.browsers.new("package://files/Tuning/lscustoms/home.html");
            mp.events.callRemote("ResetVehicleMod");
            mp.gui.cursor.visible = true;
        }
    },
    "Display_Tunning_pages": (name) => {
        mp.events.call("hidePoliceCivilMenu");
        if (Tuning_Browsers === undefined) {
            mp.gui.chat.push(name);
            Tuning_Browsers = mp.browsers.new("package://files/Tuning/lscustoms/"+name+".html");
            mp.gui.cursor.visible = true;
        }
    },
    "tunning_onindexchange": (permanent,name,id) => {
        if (permanent) {
            mp.events.callRemote("tunning_select", name, id);
        } else {
            mp.events.callRemote("tunning_preview",name,id);

        }
    },
    "tunning_MainMenuRespone": (name) => {
        mp.events.callRemote("MainMenuRespone", name);
    },
    "Display_Tunning_with_data": (data, name) => {
        mp.events.call("hidePoliceCivilMenu");
        if (Tuning_Browsers === undefined) {
        //    mp.console.logInfo(JSON.parse(data)[1].modValue + " " + JSON.parse(data)[1].price + " " + JSON.parse(data)[1].Label, false, false);

            Tuning_Browsers = mp.browsers.new("package://files/Tuning/lscustoms/" + name + ".html");
            Tuning_Browsers.execute("loaddata('" + data + "');");
            mp.gui.cursor.visible = true;

        }
    },	

    "Destroy_dealership_Menu": (vehname) => {
        if (uiGlobal_Browsers != undefined) {
            mp.events.callRemote("DealershipExitMenu");
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
            mp.gui.cursor.visible = false;
            freezeMe = false;
            localPlayer.setInvincible(false);
            mp.events.call("toggle_player_hud", true);

        }
    },

    "PreviewVehicleDealership": (vehicle) => {
        mp.events.callRemote("PreviewVehicleDealership", vehicle);
    },
    
    "Business_Buy_Vehicle": (vehicle) => {
        mp.events.callRemote("BuyVehicle_FromDealership", vehicle);
    },

    "Display_Whitelist_Screen": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/auth/whitelist.html");
        }

    },
	
	"Display_FilesMissing_Screen": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/auth/files_missing.html");
        }

    },

    "LoadShopMenu": (JsonList, bussiness_name, return_name, profit_percent) => {
        if (uiGlobal_Browsers == undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/Shop/ItemShopCatalog.html");
            uiGlobal_Browsers.execute("populateBusinessItems('" + JsonList + "',' " + bussiness_name + "','" + return_name + "','" + profit_percent + "')");
            mp.gui.cursor.visible = true;
            mp.events.call("toggle_player_hud", false);
        }
        

    },
    "Closeshopmenu": () => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
            mp.gui.cursor.visible = false;
            mp.events.call("toggle_player_hud", true);
        }
    },

    "purchaseItem": (returnto, selectedname, selected, purchasedAmount) => {

        mp.gui.chat.push(returnto+" "+ selectedname+" "+ selected+" "+ purchasedAmount);
        switch (returnto) {

            case "business":
                {
                    mp.events.callRemote("BusinessShop",selected,selectedname, purchasedAmount);
                    break;
                }
            default:
                break;
        }
    },

    "Display_DealerShip_Manage": (name, type, safe, vehicles_stock, vehicles_list) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/vehicles/dealership.html");
        }

        uiGlobal_Browsers.execute("LoadBusinessManageMenu('" + name + "', '" + type + "', " + safe + ", '" + vehicles_stock + "', '" + vehicles_list + "');");
        mp.gui.cursor.visible = true;
    },

    "Display_DealerShip_Manage": (name, type, safe, vehicles_stock, vehicles_list) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/vehicles/dealership.html");
        }

        uiGlobal_Browsers.execute("LoadBusinessManageMenu('" + name + "', '" + type + "', " + safe + ", '" + vehicles_stock + "', '" + vehicles_list + "');");
        mp.gui.cursor.visible = true;
    },

    "Business_Change_Name": (new_name) => {
        mp.events.callRemote("Business_Change_Name", new_name);
    },

    "Business_Depositar_Fundos": (value) => {
        mp.events.callRemote("Business_Depositar_Fundos", value);
    },

    "Business_Retirar_Fundos": (value) => {
        mp.events.callRemote("Business_Retirar_Fundos", value);
    },

    "Business_Buy_Vehicle_Stock": (name, stock, price) => {
        mp.events.callRemote("vehicle_to_business", name, stock, price);
    },

    "Business_Save_Vehicle": (name, price, visibility) => {
        mp.events.callRemote("vehicle_save_business", name, price, visibility);
    },
    "Lockpick": () => {
        if (LockPick_Browser === undefined) {
            LockPick_Browser = mp.browsers.new("package://files/html/lockpick.html");
            mp.gui.cursor.visible = true;

        }
    },
    "LockPickResult": (result) => {
        
        if (LockPick_Browser != undefined) {
            LockPick_Browser.destroy();uiGlobal_Browsers
            LockPick_Browser = undefined;
        }
        mp.events.callRemote("LockPickResult",result)
        mp.gui.cursor.visible = false;
        
    },


    "Display_Barber": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/clothes/barber.html");
        }

        mp.gui.cursor.visible = true;
    },

    "Display_carshop": () => {
        if (autoshopbrowser === undefined) {
            autoshopbrowser = mp.browsers.new("package://files/autoshop/carshop.html");
        }

        mp.gui.cursor.visible = true;
    },
    
    "ClientOnRangeChangeBarber": (id, val) => {
        mp.events.callRemote("ClientOnRangeChangeBarber", id, val);
    },

    "Barber_Menu_Destroy": () => {
        mp.events.callRemote("Barber_Menu_Destroy");
    },

    "BuyBarber": (type) => {
        mp.events.callRemote("BuyBarber", type);
    },

    "Barber_Update_Character": () => {
        mp.events.callRemote("Barber_Update_Character");
    },


    "Display_MDC": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/MDC/PolicePanel.html");
        }

        mp.gui.cursor.visible = true;
    },
   
   
    ////NEW MDC ////
    "PersonFineAdded": (data) => {
        uiGlobal_Browsers.execute("PersonFineAdded('" + data + "');");
    },
    "PersonCaseAdded": (data) => {
        uiGlobal_Browsers.execute("PersonCaseAdded('" + data + "');");
    },
    "PersonNoteAdded": (data) => {
        uiGlobal_Browsers.execute("PersonNoteAdded('" + data + "');");
    },

    "mdcPersonAddNote": (name, reason) => {
        mp.events.callRemote("mdcPersonAddNote", name, reason);
    },
    "mdcPersonNoteDelete": (ID) => {
        mp.events.callRemote("mdcPersonNoteDelete", ID);
    },
    "mdcPersonAddCase": (name, reason, jailtime) => {
        mp.events.callRemote("mdcPersonAddCase", name, reason, jailtime);
    },
    "mdcPersonAddFine": (name, reason, price) => {
        mp.events.callRemote("mdcPersonAddFine", name, reason, price);
    },
    "mdcFindPersons": (name) => {
        mp.events.callRemote("mdcFindPersons", name);
    },
    "mdcPersonDetails": (name) => {
        mp.events.callRemote("mdcPersonDetails", name);
    },
    "mdcFindVehicles": (name) => {
        mp.events.callRemote("mdcFindVehicles", name);
    },

    "mdc_response_vehicle": (data) => {

        uiGlobal_Browsers.execute("ShowVehicles('" + data + "');");
    },
    "mdc_response_player": (data) => {

        uiGlobal_Browsers.execute("ShowPersons('" + data + "');");
    },
    "sendPersonDetails": (data, vehicles,fines,warrant) => {

        uiGlobal_Browsers.execute("ShowPersonDetails('" + data + "','" + vehicles + "','" + fines + "','" + warrant +"');");
    },
    //////  /////////
    "mdc_register_info": (name) => {
        mp.events.callRemote("mdc_response_Registered_info", name);
    },
    "mdc_response_Registered_info": (data,veh) => {

        if (uiGlobal_Browsers === undefined) {
            return;
        }
        uiGlobal_Browsers.execute("ShowRegistered('" + data + "','" + veh+"');");
    },

    "mdc_warrant_list": (name) => {
        mp.events.callRemote("mdc_warrant_list", name);
    },


    "mdc_response_warrants": (data) => {

        if (uiGlobal_Browsers === undefined) {
            return;
        }
        uiGlobal_Browsers.execute("CheckWantedList('" + data + "');");
    },

    "mdc_track_wanted": (name) => {
        mp.events.callRemote("mdc_track_wanted", name);
    },

    //
    "mdc_911_list": () => {
        mp.events.callRemote("mdc_911_list");
    },
    "mdc_911_accept": (index) => {
        mp.events.callRemote("mdc_911_accept", index);
    },
    "mdc_911_refuse": (index) => {
        mp.events.callRemote("mdc_911_refuse", index);
    },
    "mdc_response_911list": (data) => {

        if (uiGlobal_Browsers === undefined) {
            return;
        }

        uiGlobal_Browsers.execute("Check911List('" + data + "');");
    },

    "SendReport": (reportList) => {
        if (uiGlobal_Browsers === undefined) {
          uiGlobal_Browsers = mp.browsers.new("package://files/areport/index.html");
        }

        const reportListJson = JSON.stringify(reportList);
        uiGlobal_Browsers.execute(`SendingReport('${reportListJson}');`);
        mp.gui.cursor.visible = true;
      },


    "Display_Credit_Store": (arr_player, arr_store, credits) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/vip/vip.html");
        }
        uiGlobal_Browsers.execute("Load_VIP_Data('" + arr_player + "', '" + arr_store + "','"+credits+"');");
        mp.gui.cursor.visible = true;
    },
    "Buy_Item_From_Credit_Store": (index) => {
        mp.events.callRemote("BuyItemFromCreditStore", index);
    },
    "Buy_Credit_Store": (index) => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
        }
        mp.events.callRemote("Buy_Credit_Store", index);
    },

    "Display_PaymentPage": (url) => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
        }
        uiGlobal_Browsers = mp.browsers.new(""+url);
        localPlayer.ispaymentopen = true;
        mp.gui.cursor.visible = true;
    },


    "Display_Characters": (character_data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/html/characters.html");
        }
        camerasManager.setActiveCamera(selectCharacter, true);
        camerasManager.setActiveCameraWithInterp(selectCharacter, new mp.Vector3(714.19655, 1202.4187, 348.965901), new mp.Vector3(-10, 0, 160), 0, 0, 0);

        uiGlobal_Browsers.execute("LoadCharacters('" + character_data + "');");
        mp.gui.cursor.visible = true;
    },

    
    "Destroy_Character_Menu": () => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
        }
        mp.gui.cursor.visible = false;
        
        mp.game.graphics.transitionFromBlurred(1);

        mp.events.callRemote('Inventory_Close');
    },

    "SelectCharacter": (character_id) => {
        mp.events.callRemote('SelectCharacter', character_id);
    },

    "ClientPreviewCharacterID": (character_id) => {

        mp.events.callRemote('ClientPreviewCharacterID', character_id);
    },

    "CreateCharacter": () => {
        mp.events.callRemote('CreateCharacter');
    },

    "Show_Char_Creator": (character_data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/auth/personagem.html");
        }

        uiGlobal_Browsers.execute("LoadNewCharacter('" + character_data + "');");
        mp.gui.cursor.visible = true;

        localPlayer.taskPlayAnim("amb@world_human_guard_patrol@male@base", "base", 8.0, 1, -1, 1, 0.0, false, false, false);
    },

    "Show_Char_Creator_2": (character_data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/auth/personagem_2.html");
        }

        uiGlobal_Browsers.execute("LoadFaceFeatures('" + character_data + "');");
        mp.gui.cursor.visible = true;
    },

    "Show_Char_Creator_3": (character_data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/auth/personagem_3.html");
        }

        uiGlobal_Browsers.execute("LoadClothing('" + character_data + "');");
        mp.gui.cursor.visible = true;
    },

    "ClientCharCreationBack": () => {
        mp.events.callRemote('ClientCharCreationBack');
    },

    "ClientCharCreationNext": (first_name, second_name,age) => {
        mp.events.callRemote('Display_Creator_part2', first_name, second_name,age);
    },

    "ClientCharCreation2Back": () => {
        mp.events.callRemote('Display_Creator_part1');
    },

    "ClientCharCreation2Next": () => {
        mp.events.callRemote('Display_Creator_part3');
    },

    "ClientCharCreation3Back": () => {
        mp.events.callRemote('ClientCharCreation3Back');
    },

    "ClientOnRangeChange": (id, val) => {
        mp.events.callRemote('ClientOnRangeChange', id, val);
    },
    "ClientSetFaceFeature": (id, val) => {
        mp.events.callRemote('ClientSetFaceFeature', id, val);
    },
    "ClientSetTraje": (id) => {
        mp.events.callRemote('ClientSetTraje', id);
    },
    "cameraPointTo": (id) => {
        mp.events.callRemote('cameraPointTo', id);
    },
    "ClientCharCreation3Next": () => {
        mp.events.callRemote('ClientCharCreation3Next');
    },

    "hidePoliceCivilMenu": () => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
            mp.gui.cursor.visible = false;
        }
    },
    "ShowCivilPDMenu": (data) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/MDC/CivilMenu.html");
            uiGlobal_Browsers.execute("LoadFines('"+data+"');");
        }
        mp.gui.cursor.visible = true;
    },

    "createBiddingUI": (itemName, currentBid) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/auction/index.html");
            uiGlobal_Browsers.execute(`updateUI('${itemName}', ${currentBid})`);
            mp.gui.cursor.visible = true;
        }
        
    },

    "updateBidUI": (itemName, currentBid) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/auction/index.html");
            uiGlobal_Browsers.execute(`updateUI('${itemName}', ${currentBid})`);
            mp.gui.cursor.visible = true;
        }
        
    },

    "trypayfine": (id,price) => {
        mp.events.callRemote('trypayfine',id,price);
    },
    "finepaided": (id) => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.execute("DeletePaidedFine(" + id + ");");
        }
    },
    "Display_Player_Help": (jobid, leaderid, grouptype, rankid) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/helper/helper.html");
        }
        uiGlobal_Browsers.execute("LoadDataToHelp(" + jobid + ", " + leaderid + ", " + grouptype + ", " + rankid + ");");
        mp.gui.cursor.visible = true;
    },
    
    "Display_Crafting_System": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/weaponcraft/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_Polvehicles": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/lspd-gunstore/lspdvehicle/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_Emsvehicles": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/medicvehicles/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_Mehvehicles": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/mechanics/mechveh/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_carfix": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/carservice/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_carwash": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/carwash/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_medheal": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/medicalheal/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_vdismantle": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/vdismantle/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Hide_Crafting_System": () => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
            mp.gui.cursor.visible = false;
        }
        
    },

    "HideCarShop": () => {
        if (autoshopbrowser != undefined) {
            autoshopbrowser.destroy();
            autoshopbrowser = undefined;
            mp.gui.cursor.visible = false;
        }
        
    },

    "carfixes": () => {
        mp.events.callRemote("fixcarlsc");
    },

    "ccarwash": () => {
        mp.events.callRemote("carwashes");
    },

    "mmedheal": () => {
        mp.events.callRemote("medheal");
    },

    "vvdismant": () => {
        mp.events.callRemote("vdismant");
    },

    "client::craftGANG": (id) => {
        mp.events.callRemote("Craftgun", id);
    },

    "client::polvehs": (id) => {
        mp.events.callRemote("getlspdvehs", id);
    },

    "CStartQuest": () => {
        mp.events.callRemote("StartZadatak");
    },

    "client::emsvehs": (id) => {
        mp.events.callRemote("getemsvehs", id);
    },

    "client::mehvehs": (id) => {
        mp.events.callRemote("getmehvehs", id);
    },

    "client::autsalon": (id) => {
        mp.events.callRemote("AutoSalonShows", id);
    },

    "clientbveh": (selectedVehicle, color) => {
        mp.events.callRemote("VehBuy", selectedVehicle, color);
    },

    "clientvehpreview": (vehiclename, selectedColor) => {
        mp.events.callRemote("GetVehPreview", vehiclename, selectedColor);
    },

    "cexitvehshop": () => {
        mp.events.callRemote("VehPreviewExit");
    },

    "testvoznjaveh": (testveh) => {
        mp.events.callRemote("TestDriveRemote", testveh);
    },

    "ClientCarControl": (index) => {
        mp.events.callRemote("CarControl", index);
    },

    "client::buyweapon": (id) => {
        mp.events.callRemote("bweaponshop", id);
    },

    "Client:wnews:SubmitPost": (content, phonenumber) => {
        mp.events.callRemote("wnewsSubmitPost", content, phonenumber);
    },

    "Display_osiguranje": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/tablice/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    
    "Display_vehosiguranje": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/osiguranje/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_lombank": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/lombank/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_sevenstore": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/24seven/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_blackmarkets": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/blackmarket/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_lspdguns": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/lspd-gunstore/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_cartool": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/cartool/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_mechdel": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/mechanics/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_newbank": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/Bank/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_newbbank": (totmoney) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/bars/business.html");
            mp.gui.cursor.visible = true;
        }
        uiGlobal_Browsers.execute(`document.getElementById('currentbussinesmoney').innerHTML="` + totmoney + `";`);
    },

    "Display_gunsstore": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/weaponshop/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_pizzajob": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/poslovi/food_delivery/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "Display_rudarjob": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/poslovi/rudar/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_busjob": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/poslovi/bus_vozac/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_krijumcarjob": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/poslovi/krijumcar/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "Display_electricjob": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/poslovi/Elektricar/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "Display_hackerjob": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/poslovi/ehaker/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "Display_ihackerjob": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/poslovi/ihacker/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_pilicarjob": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/poslovi/Pilicar/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_opstina": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/Opstina/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_rent": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/rent/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_arent": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/aviorent/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_brent": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/boatrent/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_bars": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/bars/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_oglase": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/oglasi/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_casino": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/casino/rulet/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_casino2": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/casino/slots/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "Display_casino3": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/casino/blackjack/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "avs": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/avioskola/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "as1": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/autoskola/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "as2": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/autoskola/index2.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "as3": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/autoskola/index3.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "as4": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/autoskola/index4.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "as5": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/autoskola/index5.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "as6": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/autoskola/index6.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "ms1": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/motoskola/index.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "ms2": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/motoskola/index2.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "ms3": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/motoskola/index3.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "ms4": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/motoskola/index4.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "ms5": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/motoskola/index5.html");
            mp.gui.cursor.visible = true;
        }
        
    },
    "ms6": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/motoskola/index6.html");
            mp.gui.cursor.visible = true;
        }
        
    },

    "changeNumber": (number, type) => {
        mp.events.callRemote("changeNumber", `${number}`, type);
    },

    "cplaceBid": (bidAmount) => {
        mp.events.callRemote("placeBid", bidAmount);
    },
    "exitall": () => {
        mp.events.callRemote("ExitAH");
    },
    
    "client::sevenstore": (id) => {
        mp.events.callRemote("fourseven", id);
    },

    "client::lspdgunstore": (id) => {
        mp.events.callRemote("lspdguns", id);
    },

    "client::mechanicdelovi": (id) => {
        mp.events.callRemote("mechdel", id);
    },

    "client::pizzajob": (id) => {
        mp.events.callRemote("pizzajobs", id);
    },
    "client::rudarjob": (id) => {
        mp.events.callRemote("rudarjobs", id);
    },
    "client::busjob": (id) => {
        mp.events.callRemote("busjobs", id);
    },
    "client::krijumcarjob": (id) => {
        mp.events.callRemote("krijumcarjobs", id);
    },
    "client::hackerjob": (id) => {
        mp.events.callRemote("hackerjobs", id);
    },
    "client::ihackerjob": (id) => {
        mp.events.callRemote("ihackerjobs", id);
    },
    "client::pilicarjob": (id) => {
        mp.events.callRemote("pilicarjobs", id);
    },
    "client::electric": (id) => {
        mp.events.callRemote("electricjobs", id);
    },
    "client::opstina": (id) => {
        mp.events.callRemote("opstinajobs", id);
    },
    "InsuranceBuy": (id) => {
        mp.events.callRemote("InsuranceBuys", id);
    },
    "ExchangeRPV": (id) => {
        mp.events.callRemote("ExchangeRPVs", id);
    },
    "client::renter": (id) => {
        mp.events.callRemote("rentveh", id);
    },
    "client::arenter": (id) => {
        mp.events.callRemote("arentveh", id);
    },
    "client::brenter": (id) => {
        mp.events.callRemote("bRentveh", id);
    },
    "client::dreport": (id) => {
        mp.events.callRemote("dreport", id);
    },
    "client::lpanswer": (id, text) => {
        mp.events.callRemote("lpanswer", id, text);
    },
    "client::askola": (id) => {
        mp.events.callRemote("askola", id);
    },
    "client::amskola": (id) => {
        mp.events.callRemote("amskola", id);
    },
    "client::avskola": (id) => {
        mp.events.callRemote("avskola", id);
    },
    "client::blackmarkets": (id) => {
        mp.events.callRemote("blackmarketss", id);
    },
    "client::barstore": (id) => {
        mp.events.callRemote("barstores", id);
    },
    "Client:BankTransfareMoney": (banknumber, amount) => {
        mp.events.callRemote("BankTransfareMoney", banknumber, amount);
    },
    "Client:BankDepositMoney": (amount) => {
        mp.events.callRemote("BankDepositMoney", amount);
    },
    "Client:BankWithdrawMoney": (amount) => {
        mp.events.callRemote("BankWithdrawMoney", amount);
    },
    "Client:bBankWithdrawMoney": (amount) => {
        mp.events.callRemote("bBankWithdrawMoney", amount);
    },

    "client::ruletpobeda": (id) => {
        mp.events.callRemote("ruletpob", id);
    },
    "client::ruletzavrti": (id) => {
        mp.events.callRemote("zavrtirulet", id);
    },

    "knjiga_recepata": () => {
        if (uiGlobal_Browsers != undefined) {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
            mp.gui.cursor.visible = false;
        }

        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/lspd/knjigarec.html");
            mp.gui.cursor.visible = true;
            mp.game.graphics.transitionFromBlurred(1);
        }
        
    },

    "Display_Badge": (a,b,c) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/lspd/index.html");
        }
        ui_enable = true;
        uiGlobal_Browsers.execute(`document.getElementById('namelabel').innerHTML="` + a + `";`);
        uiGlobal_Browsers.execute(`document.getElementById('namerank').innerHTML="` + b + `";`);
        uiGlobal_Browsers.execute(`document.getElementById('snumber').innerHTML="` + c + `";`);
        mp.gui.cursor.visible = true;
    },
    //
    // First
    //
    "ShowModal": (callback_id, title, text, bottom_confirm, bottom_cancel) => {

        if (uiPlayer_Browsers != undefined) {
            uiPlayer_Browsers.execute("ShowModal('" + callback_id + "', '" + title + "', '" + text + "', '" + bottom_confirm + "', '" + bottom_cancel + "')");
            mp.gui.cursor.visible = true;
        }
    },

    "modalConfirm": (response_callback) => {
        mp.events.callRemote('modalConfirm', response_callback);
        mp.gui.cursor.visible = false;
    },

    "modalCancel": (response_callback) => {
        mp.events.callRemote('modalCancel', response_callback);
        mp.gui.cursor.visible = false;
    },

    //

    "Display_Calls": (name, arrjson) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/services/services.html");
        }

        uiGlobal_Browsers.execute("LoadCalls('" + name + "', '" + arrjson + "');");
        mp.gui.cursor.visible = true;
    },

    "Display_playerstats": (level, exp, rpvpoints, posao, skill, referral, carlic, motolic, flylic, gunlic, fishlic, organisation, orgrank) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/bars/pstats.html");
        }
    
        // Call the "updateStats" function in the HTML with the received data as arguments
        uiGlobal_Browsers.execute(`updateStats(${level}, ${exp}, ${rpvpoints}, '${posao}', ${skill}, '${referral}', ${carlic}, ${motolic}, ${flylic}, ${gunlic}, ${fishlic}, '${organisation}', '${orgrank}')`);
    
        mp.gui.cursor.visible = true;
    },

    "Service_Track": (id) => {
        mp.events.callRemote("Service_Track_Server", id);
    },

    "Service_Remove": (id) => {
        mp.events.callRemote("Service_Remove_Server", id);
    },

    //
    "rappel": (target) => {

        target.clearTasks();
        target.taskRappelFromHeli(10.0);
    },

   
    "Display_HQ_Storage": (inv, storage, limit, vehicle_limit) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/inventory2/HQ-Inventory.html");
        }

        uiGlobal_Browsers.execute("LoadInventory('" + inv + "', '" + storage + "', " + limit + ", " + vehicle_limit + ");");
        mp.gui.cursor.visible = true;
    },

    "Display_Player_Storage": (inv, storage, limit, vehicle_limit) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/inventory2/Side-Inventory.html");
            mp.game.graphics.transitionToBlurred(1);

        }


        uiGlobal_Browsers.execute("LoadInventory('" + inv + "', '" + storage + "', " + limit + ", " + vehicle_limit + ");");
        mp.gui.cursor.visible = true;
    },

    "Display_Search_inventory": (inv, storage, limit, vehicle_limit) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/inventory2/Search-inventory.html");
            mp.game.graphics.transitionToBlurred(1);

        }
        uiGlobal_Browsers.execute("LoadInventory('" + inv + "', '" + storage + "', " + limit + ", " + vehicle_limit + ");");
        mp.gui.cursor.visible = true;
    },
    "SearchInventoryRespone": (func, dataslot, index, type, amount, inventoryname) => {

        //  mp.gui.chat.push("" + func + " " + dataslot + " " + index + " " + type + " " + amount + " " + inventoryname);
        switch (func) {
            case "addtoside":
                mp.events.callRemote("Search_Give_Item", dataslot, type, amount, index);
                break;
            case "addtoinv":
                mp.events.callRemote("Search_Take_Item", dataslot, type, amount, index);
                break;
            case "drop":
                mp.events.callRemote("JogarItem", index, type, 1, 3);
                break;
            case "drop-all":
                mp.events.callRemote("JogarItem", index, type, amount, 3);
                break;
            case "use":
                mp.events.callRemote("OnClientItemAction", index, amount, 3);
                break;
            case "slot":
                mp.events.callRemote("Search_InventoryChangeSlot", index, dataslot);
                break;
            case "stack":
                mp.events.callRemote("Search_SideInventoryStack", dataslot, index);/// SQL Jadid // SQL Ghabli
                break;
            case "stack_main_iv":
                mp.events.callRemote("Search_InventoryStack", dataslot, index);/// SQL Jadid // SQL Ghabli
                break;
            case "split":
                if (inventoryname == "sideInventory") {
                    mp.events.callRemote("Search_SideInventorySplit", index);
                } else {
                    mp.events.callRemote("Search_InventorySplit", index);
                }
                break;

            default:
                break;
        }
    },

    "HQ_Storage_Give_Item": (item_type, amount) => {
        mp.events.callRemote("HQ_Storage_Give_Item", item_type, amount);
    },

    "HQ_Storage_Take_Item": (item_type, amount) => {
        mp.events.callRemote("HQ_Storage_Take_Item", item_type, amount);
    },

    "Display_Player_List": (player_list, online, max) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/html/online.html");
        }

        uiGlobal_Browsers.execute("LoadPlayers('" + player_list + "', " + online + ", " + max + ");");
        //mp.gui.cursor.visible = true;
    },

    "Display_Player_Inventory": (items, character_money, limit, weight) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/inventory2/inventory.html");
        }
        mp.events.callRemote("SetGroundPos", mp.players.local.getHeightAboveGround()-0.2);
        uiGlobal_Browsers.execute("updateBrowser('" + items + "', '"+ null+"', '"+ 0+"', '"+ null+"', '"+ false+"', '"+ null+"', '"+ false+"', '"+ null+"', '"+ 0+"', '"+ character_money+"', '"+ limit +"', '"+ weight +"');");
        mp.gui.cursor.visible = true;
    },
    "openclother": () => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/lspdcloth/index.html");
            mp.gui.cursor.visible = true;
        }else {
            uiGlobal_Browsers.destroy();
            uiGlobal_Browsers = undefined;
            mp.gui.cursor.visible = false;
        }
    },

    "Storage_Give_Item": (slot,sqlid) => {
        mp.events.callRemote("Storage_Give_Item",slot, sqlid);
    },

    "Storage_Take_Item": (item_type, amount) => {
        mp.events.callRemote("Storage_Take_Item", item_type, amount);
    },

    "Display_Player_Inventory": (items, limit, weight) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/inventory2/inventory.html");
            mp.game.graphics.transitionToBlurred(1);


        }
        mp.events.callRemote("SetGroundPos", mp.players.local.getHeightAboveGround()-0.2);
        uiGlobal_Browsers.execute("LoadInventory('" + items + "','"+ limit +"', '"+ weight +"');");
        mp.gui.cursor.visible = true;
    },

    "Display_Player_NotfMenu": (title, bigtext, description,html) => {
        if (uiGlobal_Notifiaction === undefined) {
            uiGlobal_Notifiaction = mp.browsers.new("package://files/html/notf.html");
        }
        if (html == undefined) { html = "";}
        uiGlobal_Notifiaction.execute("UpdateNotf('" +title +"','" +bigtext +"','"+description+"','"+html+"');");
        
    },
    "Destroy_NotfMenu": () => {
        if (uiGlobal_Notifiaction != undefined) {
            uiGlobal_Notifiaction.destroy();
            uiGlobal_Notifiaction = undefined;
        }
    },
    "Display_House_Storage": (inv, storage, limit, vehicle_limit) => {
        if (uiGlobal_Browsers === undefined) {
            uiGlobal_Browsers = mp.browsers.new("package://files/inventory2/House-Inventory.html");
            mp.game.graphics.transitionToBlurred(1);

        }
        uiGlobal_Browsers.execute("LoadInventory('" + inv + "', '" + storage + "', " + limit + ", " + vehicle_limit + ");");
        mp.gui.cursor.visible = true;
    },

    "House_Storage_Give_Item": (item_type, amount) => {
        mp.events.callRemote("House_Storage_Give_Item", item_type, amount);
    },

    "House_Storage_Take_Item": (item_type, amount) => {
        mp.events.callRemote("House_Storage_Take_Item", item_type, amount);
    },

    "HouseInventoryRespone": (func, dataslot, index, type, amount, inventoryname) => {

        switch (func) {
            case "addtoside":
                mp.events.callRemote("House_", dataslot, type, amount, index);
                break;
            case "addtoinv":
                mp.events.callRemote("House_Storage_Take_Item", dataslot, type, amount, index);
                break;
            case "drop":
                mp.events.callRemote("JogarItem", index, type, 1,3);
                break;
			case "drop-all":
                mp.events.callRemote("JogarItem", index, type, amount,3);
                break;
            case "use":
                mp.events.callRemote("OnClientItemAction", index, amount,3);
                break;
            case "slot":
                mp.events.callRemote("House_InventoryChangeSlot", index, dataslot);
                break;
            case "stack":
                mp.events.callRemote("House_SideInventoryStack", dataslot, index);/// SQL Jadid // SQL Ghabli
                break; 
            case "stack_main_iv":
                mp.events.callRemote("House_InventoryStack", dataslot, index);/// SQL Jadid // SQL Ghabli
                break;
            case "split":
                if (inventoryname == "sideInventory") {
                    mp.events.callRemote("House_SideInventorySplit", index);
                } else {
                    mp.events.callRemote("House_InventorySplit", index);
                }
                break;

            default:
                break;
        }
    },

    "HqInventoryRespone": (func, dataslot, index, type, amount, inventoryname) => {

        switch (func) {
            case "addtoside":
                mp.events.callRemote("HQ_Storage_Give_Item", dataslot, type, amount, index);
                break;
            case "addtoinv":
                mp.events.callRemote("HQ_Storage_Take_Item", dataslot, type, amount, index);
                break;
            case "drop":
                mp.events.callRemote("JogarItem", index, type, 1,3);
                break;
			case "drop-all":
                mp.events.callRemote("JogarItem", index, type, amount,3);
                break;
            case "use":
                mp.events.callRemote("OnClientItemAction", index, amount,3);
                break;
            case "slot":
                mp.events.callRemote("HQ_InventoryChangeSlot", index, dataslot);
                break;
            case "stack":
                mp.events.callRemote("HQ_SideInventoryStack", dataslot, index);/// SQL Jadid // SQL Ghabli
                break; 
            case "stack_main_iv":
                mp.events.callRemote("HQ_InventoryStack", dataslot, index);/// SQL Jadid // SQL Ghabli
                break;
            case "split":
                if (inventoryname == "sideInventory") {
                    mp.events.callRemote("HQ_SideInventorySplit", index);
                } else {
                    mp.events.callRemote("HQ_InventorySplit", index);
                }
                break;

            default:
                break;
        }
    },


    "sideInventoryRespone": (func, dataslot, index, type, amount,inventoryname) => {


        switch (func) {
            case "addtoside":
                mp.events.callRemote("Storage_Give_Item", dataslot, type, amount,index);
                break;
            case "addtoinv":
                mp.events.callRemote("Storage_Take_Item", dataslot, type, amount, index);
                break;
            case "drop":
                mp.events.callRemote("JogarItem", index, type, 1,2);
                break;
			case "drop-all":
                mp.events.callRemote("JogarItem", index, type, amount,2);
                break;
            case "use":
                mp.events.callRemote("OnClientItemAction", index, amount,2);
                break;
            case "slot":
                mp.events.callRemote("Veh_InventoryChangeSlot", index, dataslot);
                break;
            case "stack":
                mp.events.callRemote("Veh_InventoryStack", dataslot, index);/// SQL Jadid // SQL Ghabli
                break;
            case "stack_main_iv":
                mp.events.callRemote("InventoryStack", dataslot, index);/// SQL Jadid // SQL Ghabli
                break;
            case "split":
                if (inventoryname == "sideInventory") {
                    mp.events.callRemote("veh_sideinventorysplit", index);
                } else {
                    mp.events.callRemote("veh_split", index);
                }
                break;
            default:
                break;
        }
    },

    "VehStream_SetVehicleDirtLevel": (entity, dirt) => {
        try {
            if (entity && mp.vehicles.exists(entity)) {
                if (entity !== undefined) {
                    entity.setDirtLevel(dirt);
                    if (entity.getPedInSeat(-1) == mp.players.local.handle) {
                        lastdirt = dirt;
                    }
                }
            }
        } catch (e) {
        }
    },

    "InventoryRespone": (func,dataslot, sqlid, type, amount) => {


        switch (func) {
            case "drop":
                mp.events.callRemote("JogarItem", sqlid, type, 1,1);
                break;
			case "drop-all":
                mp.events.callRemote("JogarItem", sqlid, type, amount,1);
                break;
            case "use":
                mp.events.callRemote("OnClientItemAction", sqlid, amount,1);
                break;
            case "slot":
                mp.events.callRemote("InventoryChangeSlot", sqlid, dataslot);
                break;
            case "stack":
                mp.events.callRemote("Main_InventoryStack", dataslot, sqlid);/// SQL Ghabli // SQL Jadid
                break;
            case "split":
                mp.events.callRemote("Split_Main", sqlid);/// SQL Ghabli // SQL Jadid
                break;
            case "drop_gun":
                mp.events.callRemote("drop_gun", sqlid);/// SQL Ghabli // SQL Jadid
                break;
            default:
                break;
        }
    },


    "InventoryService:ToggleClothing": (type) => {
        mp.events.callRemote("InventoryService:ToggleClothing", type);
    },
	
    "handle_seatbelt": (toggled) => {
        mp.game.invoke("SET_PED_CONFIG_FLAG", mp.players.local, 32, toggled);
    },

    "SetProgressBar": (value, name) => {

        if (uiProgressBar_Browsers === undefined) {
            uiProgressBar_Browsers = mp.browsers.new("package://files/progressbar/index.html");
        }

        uiProgressBar_Browsers.execute("StartProgressBar('" + value + "', '" + name + "')");

    },

    "DestroyProgressBar": () => {
        try {
            if (uiProgressBar_Browsers != undefined) {
                uiProgressBar_Browsers.destroy();
                uiProgressBar_Browsers = undefined;
            }
        } catch (e) {
            alert(e);
        }
        
    },

    "uiGeneralInput": (callbackId, title, placeHolder, description, type) => {

        if (uiGeneralStart_Browsers === undefined) {
            uiGeneralStart_Browsers = mp.browsers.new("package://files/auth/input.html");
        } else {
            uiGeneralStart_Browsers.destroy();
            uiGeneralStart_Browsers = undefined;
            uiGeneralStart_Browsers = mp.browsers.new("package://files/auth/input.html");
        }

        uiGeneralStart_Browsers.execute("DisplayDialogFunction('" + callbackId + "', '" + title + "', '" + placeHolder + "', '" + description + "', '" + type + "')");
        mp.gui.cursor.visible = true;

    },

    "death_screen_false": () => {
        mp.game.ui.displayHud(true);
        mp.game.gameplay.setFadeOutAfterDeath(false);
        mp.game.gameplay.disableAutomaticRespawn(true);
    },

    "speed_limiter": () => {
        if (mp.players.local.isInVehicle() && mp.players.local.seat == -1) {
            var model = mp.players.local.vehicle.getModel();

            if (mp.players.local.isInVehicle() && mp.players.local.seat == -1) {
                var model = mp.players.local.vehicle.getModel();
                if (IsModelBlocked(model)) {
                    mp.game.graphics.notify("~r~Can't use Speed Limiter on this vehicle!");
                    return;
                }

                if (limitMenu == null || limitMenu == null) {
                    // first time
                    limitMenu = new Menu("Speed Limiter", "Model: ~b~" + mp.game.vehicle.getDisplayNameFromVehicleModel(model), 0, 0, 6);

                    var limits = [];
                    limits.push("No Limit");
                    for (var i = limitMultiplier; i <= 120; i += limitMultiplier) limits.push(i.toString());

                    limitSpeedItem = new UIMenuListItem("Limit", "Adjusts the speed limit.", new ItemsCollection(limits), 0);
                    limitMenu.AddItem(limitSpeedItem);

                    limitToggleItem = new UIMenuCheckboxItem("Active", "Toggles the speed limit.", (vehicleMaxSpeedEnabled[model] !== null) ? vehicleMaxSpeedEnabled[model] : false);
                    limitMenu.AddItem(limitToggleItem);

                    limitSpeedItem.ListChange.on(function(sender, new_index) {
                        var vehicle = mp.players.local.vehicle;

                        SetVehicleMaxSpeed(vehicle, (new_index == 0) ? (mp.game.vehicle.getVehicleModelMaxSpeed(mp.players.local.vehicle.model) * 3.6) : parseInt(limitSpeedItem.IndexToItem(new_index)));
                        SetVehicleLimiterStatus(vehicle, GetVehicleLimiterStatus(vehicle));
                    });

                    limitToggleItem.CheckboxEvent.connect(function(sender, is_checked) {
                        SetVehicleLimiterStatus(mp.players.local.vehicle, is_checked);

                    });

                    limitMenu.RefreshIndex();
                    limitMenu.Visible = true;
                } else {
                    // update the menu
                    limitMenu.RefreshIndex();
                    limitMenu.Visible = !limitMenu.Visible;

                    if (limitMenu.Visible) {

                        var index = 0;
                        if (vehicleMaxSpeed[model] !== null) {
                            for (var i = limitMultiplier; i <= 120; i += limitMultiplier) {
                                if (i == vehicleMaxSpeed[model]) {
                                    index = (i / limitMultiplier);
                                    return;
                                }
                            }
                        }

                        limitSpeedItem.Index = index;
                        limitToggleItem.Checked = GetVehicleLimiterStatus(mp.players.local.vehicle);
                    }
                }
            }
        }
    },

    "speed_limiter_command": (args) => {
        var vehicle = mp.players.local.vehicle;
        var speed = parseInt(args);
        if (isNaN(speed)) {
            if (args == "off") {
                SetVehicleLimiterStatus(vehicle, false)
                mp.game.graphics.notify("~y~Tempomat ~r~ Iskljucen! ~N~~n~~w~");
            }
        }
        if (vehicle.getSpeed()*4.68 < speed) {
            SetVehicleMaxSpeed(vehicle, speed * 0.76);
            SetVehicleLimiterStatus(vehicle, true)
            mp.game.graphics.notify("~y~Tempomat ~g~ On! ~N~~n~~w~~b~" + speed + "KM/H~w~");
            mp.events.callRemote('Cruise_Control_Set', true, speed * 0.76);
        }
        else {
            mp.events.callRemote('Cruise_Control_Set', false,0);
        }
    },

    "VehicleModdingCalled": (price, bool) => {
        mapModToIndex = initModMap();
        mapModToPrice = initModToPrice(price);
        isAdminMenu = bool;


        menuConfirmation = createPurchConfirmMenu();

        createMainMenuVehMod();
        openMainMenuVehMod();
    },

});

mp.events.add('buygunlic', (data) => {
    mp.events.callRemote('buygunlic');
});

mp.events.add('passport', (data) => {
    
    uiPlayer_Browsers.execute(`passport.set('${data}');`);
    uiPlayer_Browsers.execute('passport.show()');
    mp.gui.cursor.visible = true;

});

mp.events.add('client_input_response', (response, inputtext) => {

    uiGeneralStart_Browsers.destroy();
    uiGeneralStart_Browsers = undefined;
    mp.events.callRemote('uiInput_response', response, inputtext);
    mp.gui.cursor.visible = false;
});

mp.events.add('client_input_destroy', (response) => {
    mp.events.callRemote('uiInput_destroy', response);
    uiGeneralStart_Browsers.destroy();
    uiGeneralStart_Browsers = undefined;
    mp.gui.cursor.visible = false;
});

mp.events.add('destroyCameraDealer', function () {
    cam.destroy();
    mp.game.cam.renderScriptCams(false, false, 3000, true, true);
});



let cinemaWindow = null;
let cinemaCamera = null;
let cinemaOpen = false;
const cinema_enter = [-1423.4061279296875, -215.29371643066406, 46.500423431396484];
const cinema_exit_here = [-1424.0640869140625, -210.75747680664062, 46.500423431396484, 3.9045610427856445];
const cinema_camera_pos = [-1426.763427734375, -230.83377075195312, 21.399110794067383];
const cinema_camera_lookat = [-1426.56396484375, -258.2504577636719, 21.399110794067383];

mp.events.add("Cinema_Open", (toggle) => {
    mp.events.callRemote("Server:Cinema_Open", toggle);
});

mp.events.add("enterCinema", () => {
    mp.game.cam.doScreenFadeOut(500);

    if (cinemaWindow == null) {
        mp.game.cam.doScreenFadeOut(500);
        localPlayer.setVelocity(0.0, 0.0, 0.0);

        setTimeout(function () {
            localPlayer.freezePosition(true);
        }, 700);
    }
});

mp.events.add("showCinemaScreen", (autor, time, url, isadm) => {

    if (cinemaWindow == null) {
        cinemaWindow = mp.browsers.new("package:/files/cinema/cinema-screen.html");

        mp.gui.cursor.show(true, true);

        cinemaCamera = mp.cameras.new("default", new mp.Vector3(cinema_camera_pos[0], cinema_camera_pos[1], cinema_camera_pos[2]), new mp.Vector3(0, 0, 0), 40);
        cinemaCamera.pointAtCoord(cinema_camera_lookat[0], cinema_camera_lookat[1], cinema_camera_lookat[2]);
        cinemaCamera.setActive(true);
        mp.game.cam.renderScriptCams(true, false, 0, true, false);

        setTimeout(function () {
            mp.game.cam.doScreenFadeIn(1000);
        }, 500);
    }

    if (isadm === true) {
        cinemaWindow.execute("DisplayMenu(true)");
    }

    uiVelo_Browsers.execute("DisplayMenu(false)");
    uiPlayer_Browsers.execute("DisplayMenu(false)");

    if (url == "null") {
        cinemaWindow.execute('clearCinema()');
    }
    else {
        cinemaWindow.execute('setCinema("' + autor + '", ' + time + ', "' + url + '")');
    }
});






mp.events.add("exitCinema", () => {

    //ENABLE_VOICE_WITH_CURSOR = false;

    mp.game.cam.doScreenFadeOut(500);

    mp.events.callRemote("exitCinema");

    setTimeout(function () {

        if (cinemaWindow != null) {
            cinemaWindow.destroy();
            cinemaWindow = null;
            mp.gui.cursor.show(false, false);
        }

        if (cinemaCamera != null) {
            cinemaCamera.setActive(false);
            cinemaCamera.destroy();
            cinemaCamera = null;
            mp.game.cam.renderScriptCams(false, false, 0, true, false);
        }

        uiVelo_Browsers.execute("DisplayMenu(true)");
        uiPlayer_Browsers.execute("DisplayMenu(true)");

       
        mp.events.callRemote("SetSafePosition", new mp.Vector3(cinema_exit_here[0], cinema_exit_here[1], cinema_exit_here[2]));
        localPlayer.setHeading(cinema_exit_here[3]);
        localPlayer.freezePosition(false);

        mp.game.cam.doScreenFadeIn(1000);

    }, 500);
});

mp.keys.bind(0x60, true, function () {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 200) return;
    //mp.events.callRemote('CreateReserve'); // Calling server event "keypress:F2"
    lastCheck = new Date().getTime();
    //mp.gui.chat.push('F2 key is pressed. This message will be shown until you release the key, because "keyhold" is true.');
});

var CraftMenu = undefined;

mp.events.add("CloseCraftMenu", () => {
    if (CraftMenu != undefined) {
        mp.events.callRemote("CloseCrafting");
        CraftMenu.destroy();
        CraftMenu = undefined;
        mp.gui.cursor.visible = false;
    }
});

mp.events.add("SendErrorToChat", (message) => {
    mp.gui.chat.push(message);
});


mp.events.add("SetDoorStat", (order,vehicle,doorid) => {
    switch (order) {
        case "OPEN":
            vehicle.setDoorOpen(doorid, false, false);
            break;
        case "CLOSE":
            vehicle.setDoorShut(doorid, false);
            break;
        default:
    }
});


var sk_markers = [];

mp.events.add('createCheckpoint', function (uid, type, position, scale, dimension, r, g, b, dir) {
    if (typeof sk_markers[uid] != "undefined") {
        sk_markers[uid].destroy();
        sk_markers[uid] = undefined;
    }
    if (dir != undefined) {
        sk_markers[uid] = mp.checkpoints.new(type, position, scale, {
            direction: dir,
            color: [r, g, b, 200],
            visible: true,
            dimension: dimension
        });
    } else {
        sk_markers[uid] = mp.markers.new(type, position, scale, {
            visible: true,
            dimension: dimension,
            color: [r, g, b, 255]
        });
    }
});

mp.events.add('deleteCheckpoint', function (uid) {
    if (typeof sk_markers[uid] == "undefined") return;
    sk_markers[uid].destroy();
    sk_markers[uid] = undefined;
});

mp.events.add('createWaypoint', function (x, y) {
    mp.game.ui.setNewWaypoint(x, y);
});

var workBlip = null;
mp.events.add('createWorkBlip', function (position) {
    if (workBlip != null) workBlip.destroy();
    workBlip = mp.blips.new(0, position, {
        name: "Posao",
        scale: 1,
        color: 49,
        alpha: 255,
        drawDistance: 100,
        shortRange: false,
        rotation: 0,
        dimension: 0
    });
});

var WLBlip = null;
mp.events.add('createWLBlip', function (position) {
    if (WLBlip != null) WLBlip.destroy();
    WLBlip = mp.blips.new(0, position, {
        name: "Wanted",
        scale: 1,
        color: 1,
        alpha: 255,
        drawDistance: 100,
        shortRange: false,
        rotation: 0,
        dimension: 0
    });
});

mp.events.add('deleteWLBlip', function () {
    if (WLBlip != null) WLBlip.destroy();
    WLBlip = null;
});

mp.events.add('deleteWorkBlip', function () {
    if (workBlip != null) workBlip.destroy();
    workBlip = null;
});


mp.events.add("CraftCompleted", (id) => {
    if (CraftMenu != undefined) {
        mp.gui.chat.push("Craft Complted "+id);
        mp.events.callRemote("CraftCompleted", id);
    }
});

mp.events.add("StartCrafting", (id) => {
    if (CraftMenu != undefined) {
        mp.gui.chat.push("StartCrafting " + id + " " + CraftingData[id].crafttime);
        CraftMenu.execute(`StartCrafting('${id}','${CraftingData[id].crafttime}')`);
    }
});

mp.events.add("CheckCraft", (id) => {
    if (CraftMenu != undefined) {
        mp.events.callRemote("CheckCraft",id);
    }
});
mp.events.add("addCinemaVideo", (url) => {

	var youtube_id = youtube_parser(url);

	if(youtube_id == false)
	{	
		showAlert('alert-red', 'URL nije ispravan!');
		return ;
	}
    mp.events.callRemote("addCinemaVideo", url);

});

let freezeMe = false;
let freezeVehicle = false;

mp.events.add("freeze", (bool) => {
    //freezeMe = bool;
    mp.players.local.freezePosition(bool);
});

mp.events.add("load_quest", (data) => {
    //freezeMe = bool;
    var many = mp.browsers.new("package://files/html/faction-join-test.html");
    many.execute("LoadQuestion(" + data + ")");

    mp.gui.cursor.visible = true;
});

mp.events.add("freezeEx", (bool) => {
    freezeMe = bool;
});

mp.events.add("freezeVehicle", (bool) => {
    //freezeMe = bool;
    freezeVehicle = bool;
});

var displayMessage = null;

mp.events.add("mes", (string) => {
    //freezeMe = bool;
    mp.gui.chat.push(string);
});

mp.events.add("PucanjeStakla", () => {
    mp.game.audio.playSoundFrontend(-1, "Barge_Door_Glass", "dlc_h4_Prep_FC_Sounds", true);

});

mp.events.add("displayMessage", (string) => {
    //freezeMe = bool;
    displayMessage = string;
});

var bottomText = null;
var bottomTextTime = -1;
var bottomTextInterval = null;

mp.events.add("showBottomText", (message, time = 5000) => {
    bottomText = message;
    bottomTextTime = time;
    bottomTextInterval = setInterval(() => {
        if (bottomTextTime == 0 || bottomTextTime < 0) {
            clearInterval(bottomTextInterval);
            bottomTextInterval = null;
            return bottomTextTime = -1
        }
        bottomTextTime -= 1000;
    }, 1000);
});

const drawText = (text, position, options) => {
    options = {
        ...{
            align: 1,
            font: 4,
            scale: 0.3,
            outline: true,
            shadow: true,
            color: [255, 255, 255, 255]
        },
        ...options
    };

    const ui = mp.game.ui;
    const font = options.font;
    const scale = options.scale;
    const outline = options.outline;
    const shadow = options.shadow;
    const color = options.color;
    const wordWrap = options.wordWrap;
    const align = options.align;

    ui.setTextEntry("CELL_EMAIL_BCON");
    for (let i = 0; i < text.length; i += 99) {
        const subStringText = text.substr(i, Math.min(99, text.length - i));
        mp.game.ui.addTextComponentSubstringPlayerName(subStringText);
    }

    ui.setTextFont(font);
    ui.setTextScale(scale, scale);
    ui.setTextColour(color[0], color[1], color[2], color[3]);

    if (shadow) {
        mp.game.invoke(Natives.SET_TEXT_DROP_SHADOW);
        ui.setTextDropshadow(2, 0, 0, 0, 255);
    }

    if (outline) {
        mp.game.invoke("0x2513DFB0FB8400FE");
    }

    switch (align) {
        case 1:
            {
                ui.setTextCentre(true);
                break;
            }
        case 2:
            {
                ui.setTextRightJustify(true);
                ui.setTextWrap(0.0, position[0] || 0);
                break;
            }
    }

    if (wordWrap) {
        ui.setTextWrap(0.0, (position[0] || 0) + wordWrap);
    }

    ui.drawText(position[0] || 0, position[1] || 0);
}

let turf_name = "";

mp.events.add("CurrentTurf", (name) => {
    turf_name = name;
});

let scoreboard_turf = "";
mp.events.add("Display_turfScoreBoard", (name) => {
    scoreboard_turf = name;
});


let isTaxiFare = false;
let isCustomer = false;
let currentToPay = 0;
let currentFare = 0;

mp.events.add("update_taxi_fare", (arg1, arg2, arg3, arg4) => {

    isTaxiFare = arg1;
    currentFare = arg2;
    currentToPay = arg3;
    isCustomer = arg4;

});

//var taxiFare = "Fare charge";
let taxiFare = "Ваш тариф";
let taxiFareInfo = "За каждые 10 секунд";
let dollar = "$";

let taxiCustomer = "Клиент";
let taxiCustomerInfo = "Заплатит";
let taxiCustomerAsk = "Комиссия к оплате";

const maxDistance = 25 * 25;
var lasthealth = 100;
mp.nametags.enabled = false;

mp.events.add("vehicleDistance", (amount) => {
    ui_distance = amount;
});

//
//
//
//
//
//





var res = false;


let turf_active = 0,
    turf_war_name = "",
    turf_time_left = 0,
    turf_attack_name = "",
    turf_attack_kills = 0,
    turf_attack_points = 0,
    turf_defend_name = "",
    turf_defend_kills = 0,
    turf_defend_points = 0;

mp.events.add('UpdateTurfScoreBoard', (name, time, att_name, att_kills, att_points, defend_name, defend_kills, defend_points) => {
    turf_active = 1;

    turf_war_name = name;
    turf_time_left = time;

    turf_attack_name = att_name;
    turf_attack_kills = att_kills;
    turf_attack_points = att_points;

    turf_defend_name = defend_name;
    turf_defend_kills = defend_kills;
    turf_defend_points = defend_points;
});

mp.events.add('HideTurfScoreBoard', () => {
    turf_active = 0;
});




var entity = null;

var res_2 = mp.game.graphics.getScreenActiveResolution(1, 1);

function getLookingAtEntity() {
    let startPosition = localPlayer.getBoneCoords(12844, 0.5, 0, 0);
    let secondPoint = mp.game.graphics.screen2dToWorld3d([res_2.x / 2, res_2.y / 2, (2 | 4 | 8)]);
    if (secondPoint == undefined) return null;

    startPosition.z -= 0.3;
    const result = mp.raycasting.testPointToPoint(startPosition, secondPoint, localPlayer, (2 | 4 | 8 | 16));
	

    if (typeof result !== 'undefined') {
        if (typeof result.entity.type === 'undefined') {return null; }
        if (result.entity.type == 'object' && result.entity.getVariable('TYPE') == undefined) { return null; }
		
        let entPos = result.entity.position;
        let lPos = localPlayer.position;
        if (mp.game.gameplay.getDistanceBetweenCoords(entPos.x, entPos.y, entPos.z, lPos.x, lPos.y, lPos.z, true) > 4) return null;
        return result.entity;
    }
    return null;
}

setInterval(() => {
    if (mp.players.local === null || mp.players.local === undefined || logged === 0) return;

    let player = mp.players.local;
    if (player.isSittingInAnyVehicle()) {
        let vehicle = mp.players.local.vehicle;

        if (vehicle != null && player.handle == vehicle.getPedInSeat(-1)) {
            if (uiVelo_Browsers != undefined) {
                if (velocimer_ui == false) {
                    uiVelo_Browsers.execute('DisplayVeh(true);');
                    velocimer_ui = true;
                }
               

                ui2_fuel = localPlayer.vehicle.getVariable('vehicle_fuel_client');
                let displaySpeed = Math.round(4.68 * vehicle.getSpeed());


                uiVelo_Browsers.execute('UpdateSpeed(' + displaySpeed + ',' + ui2_fuel + ',' + vehicle.getIsEngineRunning() + ',' + vehicle.gear + ',' + vehicle.getDoorLockStatus()+');');

            }
        }

    } else {
        if (velocimer_ui == true && uiVelo_Browsers != undefined) {
            uiVelo_Browsers.execute('DisplayVeh(false);');
            velocimer_ui = false;
        }
    }
}, 50);


mp.events.add('micstats', (stats) => {
    uiVelo_Browsers.execute('SetPlayerVoice('+stats+')');
});


mp.events.add('notify', (type, layout, msg, time) => {
    if (mp.players.local === null || mp.players.local === undefined || logged === 0) return;
    if (uiPlayer_Browsers !== undefined) {
        uiPlayer_Browsers.execute(`notify(${type},${layout},'${msg}',${time})`);
    }
});




const width_x = 0.03; // Ширина
const height_x = 0.0050; // Высота
const border_x = 0.001; // Обвока

const Natives = {
    IS_RADAR_HIDDEN: "0x157F93B036700462",
    IS_RADAR_ENABLED: "0xAF754F20EB5CD51A",
    SET_TEXT_OUTLINE: "0x2513DFB0FB8400FE"
};
let isMetric = false;
let minimap = {};
let streetName = "";
let zoneName = "";

function drawText2(text, drawXY, font, color, scale, alignRight = false) {
    mp.game.ui.setTextEntry("STRING");
    mp.game.ui.addTextComponentSubstringPlayerName(text);
    mp.game.ui.setTextFont(font);
    mp.game.ui.setTextScale(scale, scale);
    mp.game.ui.setTextColour(color[0], color[1], color[2], color[3]);
    mp.game.invoke(Natives.SET_TEXT_OUTLINE);

    if (alignRight) {
        mp.game.ui.setTextRightJustify(true);
        mp.game.ui.setTextWrap(0, drawXY[0]);
    }

    mp.game.ui.drawText(drawXY[0], drawXY[1]);
}
let IsInNCZ = false;
let NCZText = "";
mp.events.add('NCZ', (text) => {
    if (text == "Exit") {
        IsInNCZ = false;
    }
    else {
        NCZText = text;
        IsInNCZ = true;
    }
});

let EpochTime = "";
mp.events.add('EpochTime', (Time) => {
    EpochTime = Time;
});

setInterval(() => {
    if (localPlayer.getVariable("status") != undefined) {
        isMetric = mp.game.gameplay.getProfileSetting(227) == 1;
        minimap = getMinimapAnchor();

        const position = mp.players.local.position;
        let getStreet = mp.game.pathfind.getStreetNameAtCoord(position.x, position.y, position.z, 0, 0);
        zoneName = mp.game.ui.getLabelText(mp.game.zone.getNameOfZone(position.x, position.y, position.z));
        streetName = mp.game.ui.getStreetNameFromHashKey(getStreet.streetName);
        if (getStreet.crossingRoad && getStreet.crossingRoad != getStreet.streetName) streetName += ` / ${mp.game.ui.getStreetNameFromHashKey(getStreet.crossingRoad)}`;
    }
        
}, 500);



function getMinimapAnchor() {
    let sfX = 1.0 / 20.0;
    let sfY = 1.0 / 20.0;
    let safeZone = mp.game.graphics.getSafeZoneSize();
    let aspectRatio = mp.game.graphics.getScreenAspectRatio(false);
    let resolution = mp.game.graphics.getScreenActiveResolution(0, 0);
    let scaleX = 1.0 / resolution.x;
    let scaleY = 1.0 / resolution.y;

    let minimap = {
        width: scaleX * (resolution.x / (4 * aspectRatio)),
        height: scaleY * (resolution.y / 5.674),
        scaleX: scaleX,
        scaleY: scaleY,
        leftX: scaleX * (resolution.x * (sfX * (Math.abs(safeZone - 1.0) * 10))),
        bottomY: 1.0 - scaleY * (resolution.y * (sfY * (Math.abs(safeZone - 1.0) * 10))),
    };

    minimap.rightX = minimap.leftX + minimap.width;
    minimap.topY = minimap.bottomY - minimap.height;
    return minimap;
}

mp.events.add('HUD_Draw_stats', (stats) => {
    HUD_SHOW = stats;
});

var HUD_SHOW = true;
mp.events.add('render', (nametags) => {
    try {
        if (mp.players.local === null || mp.players.local === undefined || logged == false)
            return;
        if (HUD_SHOW) {
            if (IsInNCZ) {
                drawText2(NCZText, [minimap.rightX + 0.01, minimap.bottomY - 0.061], 2, [255, 255, 255, 255], 0.3);
            }
          //  drawText2(EpochTime, [minimap.rightX + 0.01, minimap.bottomY - 0.011], 4, [255, 255, 255, 255], 0.4);
         //   drawText2(zoneName + ' | ' + streetName, [minimap.rightX + 0.01, minimap.bottomY - 0.02], 4, [255, 255, 255, 255], 0.4);
        }

        if (CarryItem == true) {
            for (let i = 0; i < controlsToDisable.length; i++) {
                mp.game.controls.disableControlAction(2, controlsToDisable[i], true);
            }
        }


        if (localPlayer.isPlayingAnim("anim@heists@ornate_bank@grab_cash", "intro", 3) || localPlayer.isPlayingAnim("reaction@intimidation@1h", "intro", 3)) {
            mp.game.controls.disableControlAction(0, 24, true);
            mp.game.controls.disableControlAction(0, 257, true);
        }

        controls.disableControlAction(0, 243, true);

        if (!res) {
            resolution = mp.game.graphics.getScreenResolution(0, 0);
            if (resolution.x < 1920) {
                res_X = resolution.x;
                res_Y = resolution.y;
            }
            res = true;
        }


        if (controls.isDisabledControlJustPressed(0, 58)) {
            if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
            mp.events.call('pressgkey');
        }

        var player = mp.players.local;
        if (mp.players.local === undefined || mp.players.local === null)
            return;
        //var inVeh = player.isInVehicle();

        const graphics = mp.game.graphics;
        const screenRes = graphics.getScreenResolution(0, 0);

        if (lasthealth - player.getHealth() >= 5) {
            mp.events.callRemote("OnPlayerHealthChange", lasthealth - player.getHealth());
        }
        lasthealth = player.getHealth();


        if (chatopened && uiGlobal_Browsers != undefined && uiGeneralStart_Browsers != undefined && mp.gui.cursor.visible) {
            mp.game.controls.disableControlAction(2, 199, true);

        }

        if (mp.gui.cursor.visible == true && !chatopened) {
            mp.game.controls.enableControlAction(2, 249, true);
        }

        mp.game.player.setHealthRechargeMultiplier(0.0);
        mp.game.player.restoreStamina(100);
    


        if (logged != 0) {


            if (mp.players.local.hasBeenDamagedByAnyPed()) {
                mp.players.forEachInStreamRange((player, id) => {
                    if (player != mp.players.local) {
                        if (mp.players.local.hasBeenDamagedBy(player.handle, true)) {
                            mp.events.callRemote("DamageSystem_OnDamagedByPed", player, mp.players.local.getLastDamageBone(0));
                            mp.players.local.clearLastDamage();
                            return;
                        }
                    }
                });
                mp.players.local.clearLastDamage();
            }


            const controls = mp.game.controls;


            if (global.chatopened) {
                //DisableControl([0,16,17,21,22,23,24,25,26,28,29,30,31,32,33,34,35,37,44,45,50,53,54,55,58,68,69,70,71,75,79,86,91,140,141,142,199,257,278,279,280,281], true);
                mp.game.controls.disableAllControlActions(2);

                mp.game.controls.enableControlAction(2, 1, true);
                mp.game.controls.enableControlAction(2, 2, true);
                mp.game.controls.enableControlAction(2, 3, true);
                mp.game.controls.enableControlAction(2, 4, true);
                mp.game.controls.enableControlAction(2, 5, true);
                mp.game.controls.enableControlAction(2, 6, true);
                mp.game.controls.enableControlAction(2, 249, true);
                mp.game.controls.enableControlAction(2, 286, true);
                mp.game.controls.enableControlAction(2, 287, true);
                mp.game.controls.enableControlAction(2, 290, true);
                mp.game.controls.enableControlAction(2, 291, true);
                mp.game.controls.enableControlAction(2, 292, true);
                mp.game.controls.enableControlAction(2, 293, true);
                mp.game.controls.enableControlAction(2, 294, true);
                mp.game.controls.enableControlAction(2, 295, true);
                mp.game.controls.enableControlAction(2, 270, true);
                mp.game.controls.enableControlAction(2, 271, true);
                mp.game.controls.enableControlAction(2, 272, true);
                mp.game.controls.enableControlAction(2, 273, true);
                mp.game.controls.enableControlAction(2, 329, true);
                mp.game.controls.enableControlAction(2, 330, true);
            }

            if (mp.keys.isDown(17) === true) {
                CTRL = true;
            } else {
                CTRL = false;
            }

            
            if (localPlayer.getVariable('UI_Stats') == true) {

            nametags.forEach(nametag => {
                let [player, x, y, distance] = nametag;
                var isVisible = true;
                if (player.getVariable('nametag_visible') != null)
                    isVisible = player.getVariable('nametag_visible');

                let hitData;

                if (!player.isInAnyVehicle(false)) {
                    const startPosition = mp.players.local.getBoneCoords(12844, 0.3, 0.15, 0);
                    const endPosition = player.getBoneCoords(12844, 0.3, 0.15, 0);

                    hitData = mp.raycasting.testPointToPoint(startPosition, endPosition);

                    
                } else {
                    const startPosition = mp.players.local.getBoneCoords(12844, 0.3, 0.15, 0);
                    const endPosition = player.getBoneCoords(12844, 0.3, 0.50, 0);

                    hitData = mp.raycasting.testPointToPoint(startPosition, endPosition);

                    
                }
               
                
            

                if (isVisible && logged && !hitData) {
                   
                    if (distance <= maxDistance) {
                        let scale = 1 - (distance / maxDistance);
                        let diff = Math.abs(scale * 100) / 100;
                        if (scale < 0.4) {
                            scale = 0.4;
                        } else if (scale > 0.7) scale = 0.7;

                        y += 0.02 * scale;

                        if (distance <= 10 * 10 && player.getVariable('badgename') != undefined && player.getVariable('badgeon') == true) {
                            mp.game.graphics.drawText("~b~" + player.getVariable('badgename') + " #" + player.getVariable('badgenumber') + "", [x , y - (0.02)], {
                                font: 4,
                                color: [255, 255, 255, 255],
                                scale: [scale * 0.6, scale * 0.6],
                                outline: true,
                                centre: false
                            });
                        }

                        var health = player.getHealth();
                        health = health < 100 ? 0 : ((health - 100) / 100);
                        var color2 = color;
                        if (player.getVariable('nametag_color') != null) {
                            color2 = player.getVariable('nametag_color');

                            if (color2 == "red")
                                color = [255, 0, 0, 255];
                            else if (color2 == "white")
                                color = [255, 255, 255, 255];
                        }
                        

                        if (player.getVariable('isadmininvicible') == true) {

                            mp.game.graphics.drawText(' ', [x + ((0 * 0.5) * 0.25), y + (0.008 * scale)], {
                                font: 0,
                                color: color,
                                scale: [scale * 0.6, scale * 0.6],
                                outline: true,
                                centre: false
                            });

                        }
                        else {

              
                            if (player.getVariable('character_level') <= 3) {
                                mp.game.graphics.drawText("[NOVI]", [x + ((0 * 0.5) * 0.25), y + (-0.055 * scale)], {
                                    font: 0,
                                    color: [237, 203, 14, 200],
                                    scale: [scale * 0.4, scale * 0.4],
                                    outline: true,
                                    centre: false
                                });
                            }
                            if (player.getVariable('character_wanted_level') > 6) {
                                mp.game.graphics.drawText("[WANTED]", [x + ((0 * 0.5) * 0.25), y - (0.025 * scale)], {
                                    font: 0,
                                    color: [250, 0, 0, 255],
                                    scale: [scale * 0.4, scale * 0.4],
                                    outline: true,
                                    centre: false
                                });
                            }
                            if (player.getVariable('admin_shared_name') === 0) {
                                var skip = 0;
                                color = [255, 255, 255, 255];
                                if (player.getVariable('Injured') == 1) {
                                    color = [218, 69, 69, 255];
                                }
                                if (player.getVariable('using_mask')) {

                                    mp.game.graphics.drawText("[" + player.getVariable('remoteID') + "] Maska_" + player.getVariable('unknow_sqlid') + "", [x + ((0 * 0.5) * 0.25), y + (0.008 * scale)], {
                                        font: 0,
                                        color: color,
                                        scale: [scale * 0.6, scale * 0.6],
                                        outline: true,
                                        centre: false
                                    });

                                } else {
                                    for (let i = 0; i < 100; i++) {
                                        if (player.getVariable('unknow_sqlid') == mp.players.local.getVariable('know_player_' + i)) {
                                            mp.game.graphics.drawText("[" + player.getVariable('remoteID') + "] " + player.name, [x + ((0 * 0.5) * 0.25), y + (0.008 * scale)], {
                                                font: 0,
                                                color: color,
                                                scale: [scale * 0.6, scale * 0.6],
                                                outline: true,
                                                centre: false
                                            });

                                            skip = 1;
                                        }


                                    }

                                    if (skip == 0) {

                                        mp.game.graphics.drawText("" + player.name, [x + ((0 * 0.5) * 0.25), y + (0.008 * scale)], {
                                            font: 0,
                                            color: color,
                                            scale: [scale * 0.6, scale * 0.6],
                                            outline: true,
                                            centre: false
                                        });


                                    }
                                }
                            } else {
                                if (player.getVariable('admin_shared_color') === 2) {
                                    color = [15, 92, 149, 255];
                                } else if (player.getVariable('admin_shared_color') === 1) {
                                    color = [156, 0, 0, 255];
                                } else color = [177, 5, 185, 255];

                                mp.game.graphics.drawText('~r~[' + adminrank[(player.getVariable('admin_level')-1)].toString()+']~w~ ' + player.getVariable('admin_shared_name'), [x + ((0 * 0.5) * 0.25), y + (0.008 * scale)], {
                                    font: 4,
                                    color: color,
                                    scale: [scale * 0.6, scale * 0.6],
                                    outline: true,
                                    centre: false
                                });

                                }
                            if (player.getVariable("enableChatInput") === true) {
                                mp.game.graphics.drawText("Pise...", [x + ((0 * 0.5) * 0.25), y - (0.005 * scale)], {
                                    font: 4,
                                    color: [194, 194, 194, 255],
                                    scale: [scale * 0.35, scale * 0.35],
                                    outline: true,
                                    centre: false
                                });


                            } else if (player.getVariable("enableVoiceInput") === true) {
                                mp.game.graphics.drawText("Prica...", [x + ((0 * 0.5) * 0.25), y - (0.005 * scale)], {
                                    font: 4,
                                    color: [194, 194, 194, 255],
                                    scale: [scale * 0.35, scale * 0.35],
                                    outline: true,
                                    centre: false
                                });


                            }else if (player.getVariable("emoteText") !== "") {
                                mp.game.graphics.drawText(player.getVariable("emoteText"), [x, y - (0.011)], {
                                    font: 4,
                                    color: [151, 1, 255, 255],
                                    scale: [scale * 0.45, scale * 0.45],
                                    outline: true,
                                    centre: false
                                });
                            }
                        }   

                        

                        
                    }
                }
            })
            }
            


            if (freezeMe) {
                mp.game.controls.disableAllControlActions(2);

                mp.game.controls.enableControlAction(2, 1, true);
                mp.game.controls.enableControlAction(2, 2, true);
                mp.game.controls.enableControlAction(2, 3, true);
                mp.game.controls.enableControlAction(2, 4, true);
                mp.game.controls.enableControlAction(2, 5, true);
                mp.game.controls.enableControlAction(2, 6, true);
                mp.game.controls.enableControlAction(2, 249, true);
                mp.game.controls.enableControlAction(2, 286, true);
                mp.game.controls.enableControlAction(2, 287, true);
                mp.game.controls.enableControlAction(2, 290, true);
                mp.game.controls.enableControlAction(2, 291, true);
                mp.game.controls.enableControlAction(2, 292, true);
                mp.game.controls.enableControlAction(2, 293, true);
                mp.game.controls.enableControlAction(2, 294, true);
                mp.game.controls.enableControlAction(2, 295, true);
                mp.game.controls.enableControlAction(2, 270, true);
                mp.game.controls.enableControlAction(2, 271, true);
                mp.game.controls.enableControlAction(2, 272, true);
                mp.game.controls.enableControlAction(2, 273, true);
                mp.game.controls.enableControlAction(2, 329, true);
                mp.game.controls.enableControlAction(2, 330, true);
                mp.game.controls.enableControlAction(2, 200, true);

                mp.game.controls.disableControlAction(2, 71, true);
                mp.game.controls.disableControlAction(2, 72, true);

                mp.game.controls.disableControlAction(2, 75, true);

            }

            if (bottomTextTime != -1) {
                mp.game.ui.setTextFont(7);
                mp.game.ui.setTextEntry2("STRING");
                mp.game.ui.addTextComponentSubstringPlayerName(bottomText);
                mp.game.ui.drawSubtitleTimed(1, true);
            }


            if (logged) {


                if (!localPlayer.isInAnyVehicle(false) && !localPlayer.isDead()) {
                    entity = getLookingAtEntity();
                    //getNearestObjects();
                    
                } else {
                    entity = null;
                }
    
                if (entity != null) {
                    mp.game.graphics.drawText("~w~-~g~M~w~-~n~", [entity.position.x, entity.position.y, entity.position.z], {
                        font: 4,
                        color: [255, 255, 255, 185],
                        scale: [0.4, 0.4],
                        outline: true
                    });
    
                }

                

                if (freezeVehicle) {
                    mp.game.controls.disableControlAction(2, 71, true);
                    mp.game.controls.disableControlAction(2, 72, true);
                }

                if (mp.game.invoke(getNative('IS_CUTSCENE_ACTIVE'))) {
                    mp.game.invoke(getNative('STOP_CUTSCENE_IMMEDIATELY'))
                }

                if (mp.game.invoke(getNative('GET_RANDOM_EVENT_FLAG'))) {
                    mp.game.invoke(getNative('SET_RANDOM_EVENT_FLAG'), false);
                }

                if (mp.game.invoke(getNative('GET_MISSION_FLAG'))) {
                    mp.game.invoke(getNative('SET_MISSION_FLAG'), false);
                }

                mp.game.ui.hideHudComponentThisFrame(6);
                mp.game.ui.hideHudComponentThisFrame(7);
                mp.game.ui.hideHudComponentThisFrame(8);
                mp.game.ui.hideHudComponentThisFrame(9);


                mp.game.graphics.drawLightWithRange(1137, -1542, 48, 255, 255, 255, 25, 1);
                mp.game.graphics.drawLightWithRange(1140, -1578, 41, 255, 255, 255, 25, 1);
                mp.game.graphics.drawLightWithRange(-1019, -2797, 29, 255, 255, 255, 40, 0.8);
                mp.game.graphics.drawLightWithRange(-1055.307, -2806.795, 22.5, 255, 255, 255, 40, 0.8);
                mp.game.graphics.drawLightWithRange(-1067.206, -2799.9325, 22.5, 255, 255, 255, 40, 0.8);
                mp.game.graphics.drawLightWithRange(-1056, -2786, 25, 255, 255, 255, 40, 0.8);
                mp.game.graphics.drawLightWithRange(-1090, -2781, 25, 255, 255, 255, 40, 1);

                if (scoreboard_turf != "") {
                    drawText(scoreboard_turf, [120 / res_X, (res_Y - 248) / res_Y], {
                        font: 0,
                        color: [255, 255, 255, 188],
                        scale: 0.35,
                        outline: true,
                        align: 1,
                        shadow: true
                    });
                }

                if (turf_name != "") {
                    drawText(turf_name, [114 / res_X, (res_Y - 183) / res_Y], {
                        font: 7,
                        color: [255, 255, 255, 180],
                        scale: 0.35,
                        outline: true,
                        align: 1,
                        shadow: true
                    });
                }

                var color = [255, 255, 255, 150];



                if (turf_active == 1) {
                    mp.game.graphics.drawText("Rat za teritoriju (" + turf_war_name + ")", [(res_X / 2) / res_X, (res_Y - 102) / res_Y], {
                        font: 7,
                        color: [255, 255, 255, 220 - 20],
                        scale: [0.5, 0.5],
                        outline: true,
                        shadow: true,
                        centre: false
                    });

                    mp.game.graphics.drawText("~b~" + turf_defend_name + " ~w~vs ~r~" + turf_attack_name + "", [(res_X / 2) / res_X, (res_Y - 75) / res_Y], {
                        font: 7,
                        color: [255, 255, 255, 220 - 20],
                        scale: [0.35, 0.35],
                        outline: true,
                        shadow: true,
                        centre: false
                    });

                    mp.game.graphics.drawText("_________________________", [(res_X / 2) / res_X, (res_Y - 67) / res_Y], {
                        font: 4,
                        color: [255, 255, 255, 140 - 20],
                        scale: [0.3, 0.3],
                        outline: true,
                        shadow: true,
                        centre: false
                    });

                    mp.game.graphics.drawText("Poeni: ~b~" + turf_defend_points + "~w~ - ~r~" + turf_attack_points + "~n~~w~Smrti: ~b~" + turf_defend_kills + " ~w~- ~r~" + turf_attack_kills + "~n~~w~Preostalo Vreme:~y~ " + turf_time_left + "~w~ sec", [(res_X / 2) / res_X, (res_Y - 52) / res_Y], {
                        font: 4,
                        color: [255, 255, 255, 220 - 20],
                        scale: [0.3, 0.3],
                        outline: true,
                        shadow: true,
                        centre: false
                    });
                }





          if (mp.players.local.getVariable("Injured") > 0) 
			{
				if (mp.players.local.getVariable("Injured") == 1) 
				{
					if (mp.players.local.getVariable("InjuredTime") > 0) {
						mp.game.graphics.drawText("~w~Bicete transportovani u bolnicu za:~g~ "+ mp.players.local.getVariable("InjuredTime").toString() + " sekundi", [(res_X / 2) / res_X, (res_Y - 102) / res_Y], {
							font: 4,
							color: [255, 255, 255, 220 - 20],
							scale: [0.54, 0.54],
							outline: true,
							shadow: true,
							centre: false
						});



					}
					else
					{
							mp.game.graphics.drawText("~w~Otvorite meni ~w~[ ~g~O ~w~]~w~", [(res_X / 2) / res_X, (res_Y - 102) / res_Y], {
							font: 4,
							color: [255, 255, 255, 220 - 20],
							scale: [0.54, 0.54],
							outline: true,
							shadow: true,
							centre: false
						});
					}
					
                }
				
                if (mp.players.local.getVariable("Injured") == 2) 
				{
					if (mp.players.local.getVariable("InjuredTime") > 0) {
							
						mp.game.graphics.drawText("~w~Izlazite iz bolnice za:~g~ "+ mp.players.local.getVariable("InjuredTime").toString() + " sekundi", [(res_X / 2) / res_X, (res_Y - 102) / res_Y], {
							font: 4,
							color: [255, 255, 255, 220 - 20],
							scale: [0.5, 0.5],
							outline: true,
							shadow: true,
							centre: false
						});
					}
                }
            }

                if (jail_time > 0) {
                    mp.game.graphics.drawText(jail_time.toString() + " Sekundi", [0.059 + 0.032, 0.776], {

                        font: 0,

                        color: [255, 255, 255, 255],

                        scale: [0.27, 0.27],

                        outline: false

                    });

                    mp.game.graphics.drawText("~y~Sedite", [0.068 + 0.028, 0.75], {

                        font: 0,

                        color: [255, 99, 71, 255],

                        scale: [0.34, 0.34],

                        outline: false

                    });
                }




                mp.game.graphics.drawText(mp.players.local.getVariable("SubTitle"), [(res_X / 2) / res_X, (res_Y - 120) / res_Y], {
                    font: 0,
                    color: [255, 255, 255, 210],
                    scale: [0.42, 0.42],
                    outline: false,
                    centre: false
                });




                if (isTaxiFare && localPlayer.isInAnyVehicle(true)) {
                    drawText(taxiFare, [(res_X - 10) / res_X, 0.60 - 0.31], {
                        scale: 0.6,
                        color: [115, 186, 131, 255],
                        font: 4,
                        align: 2,
                        shadow: false,
                        outline: true
                    });

                    drawText(taxiFareInfo, [(res_X - 10) / res_X, 0.64 - 0.31], {
                        scale: 0.4,
                        color: [255, 255, 255, 255],
                        font: 4,
                        align: 2,
                        shadow: false,
                        outline: true
                    });

                    drawText(dollar + `${currentFare}`, [(res_X - 10) / res_X, 0.667 - 0.31], {
                        scale: 0.7,
                        color: [255, 255, 255, 255],
                        font: 4,
                        align: 2,
                        shadow: false,
                        outline: true
                    });

                    drawText(taxiCustomer, [(res_X - 10) / res_X, 0.740 - 0.31], {
                        scale: 0.6,
                        color: [115, 186, 131, 255],
                        font: 4,
                        align: 2,
                        shadow: false,
                        outline: true
                    });

                    if (isCustomer == true) {
                        drawText(taxiCustomerAsk, [(res_X - 10) / res_X, 0.784 - 0.31], {
                            scale: 0.4,
                            color: [255, 255, 255, 255],
                            font: 4,
                            align: 2,
                            shadow: false,
                            outline: true
                        });
                    } else {
                        drawText(taxiCustomerInfo, [(res_X - 10) / res_X, 0.784 - 0.31], {
                            scale: 0.4,
                            color: [255, 255, 255, 255],
                            font: 4,
                            align: 2,
                            shadow: false,
                            outline: true
                        });
                    }

                    drawText(dollar + `${currentToPay}`, [(res_X - 10) / res_X, 0.808 - 0.31], {
                        scale: 0.7,
                        color: [255, 255, 255, 255],
                        font: 4,
                        align: 2,
                        shadow: false,
                        outline: true
                    });
                }
            }
        }
    }catch (err) {
        mp.game.graphics.notify('RE:' + err.message);
    }
});



var CTRL = false;

var onSubmitGeneric = function(string) {
    mp.events.call('destroyBrowser');
    mp.events.callRemote('new_character_name', string);

};


let velocimer_ui = false;


mp.events.add("updateRankBar", (currentRankLimit, nextRankLimit, playersPreviousXP, playersCurrentXP, rank) => {
    if (!mp.game.graphics.hasHudScaleformLoaded(19)) {
        mp.game.graphics.requestHudScaleform(19);
        while (!mp.game.graphics.hasHudScaleformLoaded(19)) mp.game.wait(0);
    }

    mp.game.graphics.pushScaleformMovieFunctionFromHudComponent(19, "SET_COLOUR");
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(116); //Active bar color
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(123); //Background bar color
    mp.game.graphics.popScaleformMovieFunctionVoid();


    mp.game.graphics.pushScaleformMovieFunctionFromHudComponent(19, "SET_RANK_SCORES");
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(currentRankLimit); //current rank limit
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(nextRankLimit); //next rank limit
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(playersPreviousXP); //players previous xp
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(playersCurrentXP); //players current xp
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(rank); //rank
    mp.game.graphics.popScaleformMovieFunctionVoid();

    mp.game.graphics.pushScaleformMovieFunctionFromHudComponent(19, "OVERRIDE_ANIMATION_SPEED");
    mp.game.graphics.pushScaleformMovieFunctionParameterInt(2000);
    mp.game.graphics.popScaleformMovieFunctionVoid();
});
//var radio_status = false;
var radio_html = undefined;


mp.events.add('Toggle_Radio', () => {
    mp.events.callRemote('Toggle_Radio');
});

mp.events.add('SetFreq', (freq) => {
    mp.events.callRemote('setfreq', freq);
    if (radio_html != undefined) {
        radio_html.destroy();
        radio_html = undefined;
       // radio_status == false;
        mp.gui.cursor.visible = false;
    }
});

mp.events.add('Toggle_GUI_Radio', (freq) => {
    if (radio_html == undefined) {
        radio_html = mp.browsers.new("package://files/radio/radio.html");
        radio_html.execute("setonscreen(" + freq + ")");

        //radio_status = true;
        mp.gui.cursor.visible = true;
    } else if (radio_html != undefined) {
        //   radio_status = false;
        mp.gui.cursor.visible = false;
        radio_html.destroy();
        radio_html = undefined;

    }
});

setInterval(() => {
    if (mp.keys.isDown(0x42) === true && mp.keys.isDown(0x12) === true) { // 113 is the key code for F2
        if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 1000) return;
        mp.events.callRemote('Toggle_GUI_Radio');
    } 
}, 500);

const currentWeapon = () => mp.game.invoke(getNative("GET_SELECTED_PED_WEAPON"), localPlayer.handle);

mp.events.add('playerWeaponShot', (targetPosition, targetEntity) => {
    var current = currentWeapon();
    var ammo = mp.game.invoke(getNative("GET_AMMO_IN_PED_WEAPON"), localPlayer.handle, current);
    //mp.gui.execute(`HUD.ammo=${ammo};`);

    mp.events.callRemote('playerTakeoffWeapon', current, ammo);

});


mp.game.player.setMeleeWeaponDefenseModifier(0.25);
mp.game.player.setWeaponDefenseModifier(1.3);

var resistStages = {
    0: 0.0,
    1: 0.05,
    2: 0.07,
    3: 0.1,
};

mp.events.add("setResistStage", function (stage) {
    mp.game.player.setMeleeWeaponDefenseModifier(0.25 + resistStages[stage]);
    mp.game.player.setWeaponDefenseModifier(1.3 + resistStages[stage]);
});

mp.events.add("getNumberOfTextureVariations", function (componentId, drawableId) {
    
    mp.gui.chat.push(localPlayer.getNumberOfTextureVariations(componentId, drawableId) + "");

});

   // setInterval(() => {

   // }, 200);


// Key CODE's from https://docs.microsoft.com/en-us/windows/desktop/inputdev/virtual-key-codes
// 0x71 is the F2 key code

mp.events.add('Update_Players', (count,max) => {
    if (uiVelo_Browsers != undefined) {

        uiVelo_Browsers.execute(`setplayeronline(` + count+`,`+max+`)`);
    }
});

mp.events.add('Show_Cursor', () => {
    mp.gui.cursor.visible = true;
    cursor_status = true;
});

mp.keys.bind(0x71, true, function() {
    if (chatopened || menu_libary === true || new Date().getTime() - lastCheck < 1000) return;
    mp.gui.cursor.visible = !mp.gui.cursor.visible;
});


mp.keys.bind(0x0D, true, (player) => { // If Chat was triggered

    mp.events.call('closeChat');
});


mp.keys.bind(0x26, true, (player) => { // If Chat was triggered3
    if (chatopened == false) return;
    mp.events.call('getPreviousMessage');
});
mp.keys.bind(0x26, true, (player) => { // If Chat was triggered3

    if (chatopened === false) mp.events.call('KEY_ARROW_UP');
});

mp.keys.bind(0x28, true, (player) => { // If Chat was triggered
    if (chatopened == false) return;
    mp.events.call('getNextMessage');
});
mp.keys.bind(0x54, true, (player) => { // If Chat was triggered
    if (logged === 0 || global.circleOpen || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100)
    {
        return;
    }
    toggleChat(true);
    chatopened = true;
});

function toggleChat(toggle) {
    global.chatopened = toggle;
    global.isChat = toggle;
    mp.events.callRemote('enableChatInput', toggle);
    chat.execute("enableChatInput('" + toggle + "');");
    mp.gui.cursor.visible = toggle;
}

mp.keys.bind(0x0D, true, (player,) => { // If Chat was stopped.
    if (chatopened) {
        chatopened = false;
        mp.events.callRemote("TriggerIsTypingProcess", false);
    }
});

mp.keys.bind(0x1B, false, function () {
    if (logged === 0 || chatopened || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    if (localPlayer.ispaymentopen != undefined && localPlayer.ispaymentopen == true) {
      localPlayer.ispaymentopen = false;
      mp.gui.cursor.visible = false;
      if (uiGlobal_Browsers != undefined) {
        uiGlobal_Browsers.destroy();
        uiGlobal_Browsers = undefined; // set uiGlobal_Browsers to undefined
        mp.gui.cursor.visible = false;
      }
      mp.events.call('forceCloseChat');
      mp.events.callRemote("TriggerIsTypingProcess", false);
      mp.events.callRemote('keypress:bspc');
      return;
    }
    if (uiGlobal_Browsers != undefined) {
      mp.game.ui.setPauseMenuActive(false); // disable the GTA 5 menu
      if (uiGlobal_Browsers.browser != undefined) {
        uiGlobal_Browsers.browser.destroy();
        mp.gui.cursor.visible = false;
      }
      uiGlobal_Browsers.destroy();
      uiGlobal_Browsers = undefined; // set uiGlobal_Browsers to undefined
      mp.gui.cursor.visible = false;
      return;
    } 
    mp.game.ui.setPauseMenuActive(true); // enable the GTA 5 menu
  });

mp.keys.bind(0x30, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    if (mp.players.local.isFalling()) {
        return;
    }
	else mp.events.callRemote('keypress:0');

});

mp.keys.bind(0x31, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:1');

});
mp.keys.bind(0x32, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:2');

});
mp.keys.bind(0x33, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:3');

});
mp.keys.bind(0x34, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:4');

});
mp.keys.bind(0x35, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:5');

});
mp.keys.bind(0x36, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:6');

});
mp.keys.bind(0x37, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:7');

});
mp.keys.bind(0x38, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:8');

});
mp.keys.bind(0x39, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || CTRL === false || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:9');

});


mp.keys.bind(0x72, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('keypress:F1'); // Calling server event "keypress:F2"
    //mp.gui.chat.push('F2 key is pressed. This message will be shown until you release the key, because "keyhold" is true.');
});

mp.keys.bind(0x73, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('keypress:F4');
});

mp.keys.bind(0x74, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('KeyPress:F5');
    lastCheck = new Date().getTime();
});

mp.keys.bind(0x75, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('KeyPress:F6');
    lastCheck = new Date().getTime();
});

mp.keys.bind(0x76, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('KeyPress:F7');
    lastCheck = new Date().getTime();
});
mp.keys.bind(0x78, true, function () {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('KeyPress:F9');
    lastCheck = new Date().getTime();
});
mp.keys.bind(0x79, true, function () {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('KeyPress:F10');
    lastCheck = new Date().getTime();
});
// 0x59 is the Y key code
mp.keys.bind(0x59, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:Y');
    lastCheck = new Date().getTime();

});

mp.keys.bind(0x4A, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:J');
    lastCheck = new Date().getTime();

});


// 0x49 is the O key code
mp.keys.bind(0x4F, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:O');
    lastCheck = new Date().getTime();
});

// 0x49 is the u key code
mp.keys.bind(0x55, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

   // mp.events.callRemote('keypress:U');
    
	
    OpenCircle('animation', 0);
    lastCheck = new Date().getTime();
});

// 0x49 is the I key code
mp.keys.bind(0x49, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:I');
    lastCheck = new Date().getTime();
});

// 0x48 is the H key code
mp.keys.bind(0x48, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;

    mp.events.callRemote('keypress:H');
    lastCheck = new Date().getTime();
});

// 0x4B is the K key code
mp.keys.bind(0x4B, true, function() {

    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true ||  new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('keypress:K');
    lastCheck = new Date().getTime();

});

// 0x45 is the E key code
mp.keys.bind(0x45, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.vehicles.forEachInStreamRange((vehicle) => {
        let trunk = vehicle.getWorldPositionOfBone(vehicle.getBoneIndexByName('door_dside_r'));
        if (calcDist(localPlayer.position, trunk) < 1.2 && mp.game.vehicle.getDisplayNameFromVehicleModel(vehicle.getModel()) == "SPEEDO") {
            lastCheck = new Date().getTime();
            mp.events.callRemote('Farm_Condition');
            return;
        }
    });
    if (new Date().getTime() - lastCheck < 100) {
        return;
    }
    mp.events.callRemote('keypress:E');
    lastCheck = new Date().getTime();
    
});

// 0x4D is the M key code
mp.keys.bind(0x4D, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    
	if(entity != null)
	{
		if(entity.type == 'player')
		{

            OpenCircle('player', 0);
		}
		else if(entity.type == 'vehicle')
		{
            OpenCircle('vehicle', 0);

		}
    } else {
        mp.events.callRemote('house_KeyM');
    }
	lastCheck = new Date().getTime();
});

// 0x45 is the L key code
mp.keys.bind(0x4C, true, function() {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote('keypress:L');
    lastCheck = new Date().getTime();
});
let ui_enable = false;
// 0x45 is the INSERT key code
mp.keys.bind(0xC0, true, function () {
    if (ui_enable) {
        mp.events.call("Destroy_Character_Menu");
        ui_enable = false;
        return;
    }
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    ui_enable = true;
    mp.events.callRemote('keypress:INSERT');
    lastCheck = new Date().getTime();
});


//
// G Passege
//
function calcDist(v1, v2) {
    return mp.game.system.vdist(
        v1.x,
        v1.y,
        v1.z,
        v2.x,
        v2.y,
        v2.z
    );
}




// Take screenshot - Key: F8
mp.keys.bind(0x77, false, (player) => {
    var time = mp.game.time.getLocalTime(1, 1, 1, 1, 1, 1);
    var screenName = "SkillArena-" + time.year + "-" + time.month + "-" + time.day + "-" + time.hour + "-" + time.minute + "-" + time.second + ".png";
    mp.gui.takeScreenshot(screenName, 1, 100, 0);
    mp.game.graphics.notify("~b~Slika: \n" +
        "~s~" + screenName + "\n" +
        "~g~RAGEMP\\screenshots");
});




mp.events.add("StopVehicle", () => {
    if (localPlayer.vehicle) {
        localPlayer.vehicle.setHalt(1.5, 1, false);
    }
});

mp.keys.bind(0x25, true, function() { //Left indicator

    if (signal1 && localPlayer.vehicle) {
        signal1 = false;

        localPlayer.vehicle.setIndicatorLights(1, false);
    } else

    if (signal2 && localPlayer.vehicle) {


        localPlayer.vehicle.setIndicatorLights(1, true);
        signal1 = true;

    } else if (localPlayer.vehicle) {
 
        localPlayer.vehicle.setIndicatorLights(1, true);
        signal1 = true;

    }
});

mp.keys.bind(0x27, true, function() { // Right Indicator
    if (signal2 && localPlayer.vehicle) {
        signal2 = false;
        localPlayer.vehicle.setIndicatorLights(0, false);
    } else
    if (signal1 && localPlayer.vehicle) {

        localPlayer.vehicle.setIndicatorLights(0, true);

        signal2 = true;
    } else if (localPlayer.vehicle) {
        localPlayer.vehicle.setIndicatorLights(0, true);
        signal2 = true;
    }
});

let blinkersOn = false;

mp.events.add("CarBlinkers", () => {
    if (localPlayer.vehicle) {
        if (blinkersOn) {
            localPlayer.vehicle.setIndicatorLights(1, false);
            localPlayer.vehicle.setIndicatorLights(0, false);
            blinkersOn = false;
        } else {
            localPlayer.vehicle.setIndicatorLights(1, true);
            localPlayer.vehicle.setIndicatorLights(0, true);
            blinkersOn = true;
        }
    }
});

mp.events.add("getPedOverlay", (cash) => {

    let featureData = [];
    for (let i = 0; i < 20; i++) mp.events.callRemote("Get_Feature_Data", i, mp.game.ped.getNumHeadOverlayValues(i));

});

function getWaypointPos() {
    // GET_FIRST_BLIP_INFO_ID
    let waypointBlip = mp.game.invoke("0x1BEDE233E6CD2A1F", 8); // 8 is the ID for Waypoint blip.
    if (waypointBlip > 0) {
        // Calculate position
        var wayPointPos = mp.game.ui.getBlipInfoIdCoord(waypointBlip);
        //mp.players.local.position = wayPointPos;
        return wayPointPos;
    } else {
        // Return empty positon
        return new mp.Vector3();
    }
}


/* Speed Limiter */

function IsModelBlocked(model) {
    // model check
    if (blockedModels.indexOf(model) > -1) return true;

    // category check
    if (blockedCategories.indexOf(mp.game.vehicle.getVehicleClassFromName(model)) > -1) return true;

    // wow not blocked
    return false;
}

function SetVehicleMaxSpeed(vehicle, limit) {
    vehicleMaxSpeed[vehicle.getModel()] = limit;
    mp.events.callRemote('SetCruiseValue', limit);
}

function GetVehicleLimiterStatus(vehicle) {
    var model = vehicle.getModel();
    return (vehicleMaxSpeedEnabled[model] === null) ? false : vehicleMaxSpeedEnabled[model];
}

function SetVehicleLimiterStatus(vehicle, status) {
    var model = vehicle.getModel();

    if (status) {
        // SET_ENTITY_MAX_SPEED
        vehicle.setMaxSpeed((vehicleMaxSpeed[model] === null) ? (mp.game.vehicle.getVehicleModelMaxSpeed(model) * 3.6) : (vehicleMaxSpeed[model] / 3.6));

    } else {
        // SET_ENTITY_MAX_SPEED
        vehicle.setMaxSpeed(mp.game.vehicle.getVehicleModelMaxSpeed(model) * 3.6);
    }

    vehicleMaxSpeedEnabled[model] = status;
}

//
//
//

let customBrowser = undefined;
let parameters = [];

mp.events.add('createBrowser', (arguments) => {
    // Check if there's a browser already opened
    if (customBrowser === undefined) {
        // Save the parameters
        parameters = arguments.slice(1, arguments.length);

        // Create the browser
        customBrowser = mp.browsers.new(arguments[0]);
    }
});

mp.events.add('browserDomReady', (browser) => {
    if (customBrowser === browser) {

        mp.gui.cursor.visible = true;

        if (parameters.length > 0) {

            mp.events.call('executeFunction', parameters);
        }
    }
});

mp.events.add('executeFunction', (arguments) => {

    let input = '';

    for (let i = 1; i < arguments.length; i++) {
        if (input.length > 0) {
            input += ', \'' + arguments[i] + '\'';
        } else {
            input = '\'' + arguments[i] + '\'';
        }
    }


    customBrowser.execute(`${arguments[0]}(${input});`);
});


mp.events.add('Cloth_Store', (id) => {

    
    switch (id) {
        case 0:
            if (uiGlobal_Browsers != undefined) {
                uiGlobal_Browsers.destroy();
                uiGlobal_Browsers = undefined;
            }
            mp.events.call("ps_DestroyCamera");

            mp.gui.cursor.visible = false;
            break;
        default:
            mp.events.callRemote("Cloth_Store", id);
            
            break;
    }
});

mp.events.add('PCloth_Store', (id) => {

    
    switch (id) {
        case 0:
            if (uiGlobal_Browsers != undefined) {
                uiGlobal_Browsers.destroy();
                uiGlobal_Browsers = undefined;
            }
            mp.events.call("ps_DestroyCamera");

            mp.gui.cursor.visible = false;
            break;
        default:
            mp.events.callRemote("PCloth_Store", id);
            
            break;
    }
});



mp.events.add('BackToMainClothMenu', () => {
    mp.events.callRemote("BackToMainClothMenu" );
    if (uiGlobal_Browsers != undefined) {
        uiGlobal_Browsers.destroy();

        setTimeout(function () {
            uiGlobal_Browsers = mp.browsers.new("package://files/clothes/Main.html");
        }, 300);
    }
    mp.gui.cursor.visible = true;
});





mp.events.add('Preview_Clothes', (id, clothid, textid) => {
    mp.events.callRemote("Preview_Clothes", id, clothid, textid);
});


mp.events.add('Buy_Clothes', (id,clothid,textid,price) => {
    mp.events.callRemote("Buy_Clothes", id, clothid, textid,price);
});

mp.events.add('Display_Cloth_Selector', (data) => {
    if (uiGlobal_Browsers != undefined) {
        uiGlobal_Browsers.destroy();
    }
    setTimeout(function () {
        uiGlobal_Browsers = mp.browsers.new("package://files/clothes/select_switchers.html");
        uiGlobal_Browsers.execute("LoadList('" + data + "');");
        mp.gui.cursor.visible = true;
    }, 300);
});

mp.events.add('ShowMainClothMenu', () => {
    if (uiGlobal_Browsers === undefined) {
        uiGlobal_Browsers = mp.browsers.new("package://files/clothes/Main.html");
    }

    mp.gui.cursor.visible = true;
});


mp.events.add('DestroyClothMenu', () => {
    if (uiGlobal_Browsers != undefined) {
        uiGlobal_Browsers.destroy();
        uiGlobal_Browsers.destroy = undefined;
    }
    mp.events.callRemote("DestroyClothMenu");
    mp.gui.cursor.visible = false;

});

mp.events.add('svenm', (int1, int2) => {
	var vehc = localplayer.vehicle;
	vehc.setEnginePowerMultiplier(int1);
	vehc.setEngineTorqueMultiplier(int2);
});





mp.events.add('destroyBrowser', () => {

    mp.gui.cursor.visible = false;

    if (customBrowser != undefined) {
        customBrowser.destroy();
        customBrowser = undefined;
    }
});



//
//
//

let policeMainDoors = undefined;
let policeBackDoors = undefined;
let policeCellDoors = undefined;
let hospitalinterior = undefined;
let motorsportMain = undefined;
let motorsportParking = undefined;
let supermarketDoors = undefined;
let clubhouseDoor = undefined;
let oficina_portao = undefined;
let oficina_porta = undefined;

mp.events.add('guiReady', () => {


    hospitalinterior = mp.colshapes.newSphere(-458.7,-363.6,-186.4, 50.0);
    policeMainDoors = mp.colshapes.newSphere(468.535, -1014.098, 26.386, 5.0);
    policeBackDoors = mp.colshapes.newSphere(435.131, -981.9197, 30.689, 5.0);
    motorsportMain = mp.colshapes.newSphere(-59.893, -1092.952, 26.8836, 5.0);
    motorsportParking = mp.colshapes.newSphere(-39.134, -1108.22, 26.72, 5.0);
    supermarketDoors = mp.colshapes.newSphere(-711.545, -915.54, 19.216, 5.0);
    oficina_portao = mp.colshapes.newSphere(484.5166, -1315.502, 29.20002, 10.0);
    oficina_porta = mp.colshapes.newSphere(482.911, -1312.584, 29.20103, 10.0);
});

mp.events.add('playerWeaponShot', (targetPosition, targetEntity) => {
  let weaponHash = mp.players.local.weapon;
  let shakeType = 'SMALL_EXPLOSION_SHAKE';
  let shakeIntensity = 0.02;

  switch(weaponHash) {
    case mp.game.joaat('WEAPON_PISTOL'):
      shakeType = 'SMALL_EXPLOSION_SHAKE';
      shakeIntensity = 0.02;
      break;
    case mp.game.joaat('WEAPON_COMBATPISTOL'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.02;
        break;
    case mp.game.joaat('WEAPON_HEAVYPISTOL'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.03;
        break;
    case mp.game.joaat('WEAPON_SNSPISTOL'):
      shakeType = 'SMALL_EXPLOSION_SHAKE';
      shakeIntensity = 0.02;
      break;
    case mp.game.joaat('WEAPON_SMG'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.03;
        break;
    case mp.game.joaat('WEAPON_ASSAULTSMG'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.03;
        break;
    case mp.game.joaat('WEAPON_MINISMG'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.02;
        break;
    case mp.game.joaat('WEAPON_CARBINERIFLE'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.04;
        break;
    case mp.game.joaat('WEAPON_ASSAULTRIFLE'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.05;
        break;
    case mp.game.joaat('WEAPON_COMBATPDW'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.04;
        break;
    case mp.game.joaat('WEAPON_ADVANCEDRIFLE'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.05;
        break;
    case mp.game.joaat('WEAPON_SPECIALCARBINE'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.04;
        break;
    case mp.game.joaat('WEAPON_COMPACTRIFLE'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.04;
        break;
    case mp.game.joaat('WEAPON_PUMPSHOTGUN_MK2'):
        shakeType = 'SMALL_EXPLOSION_SHAKE';
        shakeIntensity = 0.07;
        break;
    case mp.game.joaat('WEAPON_PUMPSHOTGUN'):
      shakeType = 'SMALL_EXPLOSION_SHAKE';
      shakeIntensity = 0.08;
      break;
    // Add more cases for other weapons as needed
  }

  mp.game.cam.shakeGameplayCam(shakeType, shakeIntensity);
});


  

mp.events.add('playerEnterColshape', (shape) => {


    switch (shape) {
       
        case policeMainDoors:
            mp.game.object.doorControl(mp.game.joaat('v_ilev_ph_door002'), 434.7479, -983.2151, 30.83926, false, 0.0, 50.0, 0);
            mp.game.object.doorControl(mp.game.joaat('v_ilev_ph_door01'), 434.7479, -980.6184, 30.83926, false, 0.0, 50.0, 0);
            break;
        case policeBackDoors:
            mp.game.object.doorControl(mp.game.joaat('v_ilev_rc_door2'), 469.9679, -1014.452, 26.53623, false, 0.0, 50.0, 0);
            mp.game.object.doorControl(mp.game.joaat('v_ilev_rc_door2'), 467.3716, -1014.452, 26.53623, false, 0.0, 50.0, 0);
            break;
        case policeCellDoors:
            mp.game.object.doorControl(mp.game.joaat('v_ilev_ph_cellgate'), 461.8065, -994.4086, 25.06443, false, 0.0, 50.0, 0);
            mp.game.object.doorControl(mp.game.joaat('v_ilev_ph_cellgate'), 461.8065, -997.6583, 25.06443, false, 0.0, 50.0, 0);
            mp.game.object.doorControl(mp.game.joaat('v_ilev_ph_cellgate'), 461.8065, -1001.302, 25.06443, false, 0.0, 50.0, 0);
            break;
        case motorsportMain:
            mp.game.object.doorControl(mp.game.joaat('v_ilev_csr_door_l'), -59.89302, -1092.952, 26.88362, false, 0.0, 50.0, 0);
            mp.game.object.doorControl(mp.game.joaat('v_ilev_csr_door_r'), -60.54582, -1094.749, 26.88872, false, 0.0, 50.0, 0);
            break;
        case supermarketDoors:
            mp.game.object.doorControl(mp.game.joaat('v_ilev_gasdoor'), -711.5449, -915.5397, 19.21559, false, 0.0, 50.0, 0);
            mp.game.object.doorControl(mp.game.joaat('v_ilev_gasdoor_r'),-711.5449, -915.5397, 19.2156, false, 0.0, 50.0, 0);
            break;
        case oficina_portao:
            mp.game.object.doorControl(mp.game.joaat('prop_com_gar_door_01'), 484.5166, -1315.502, 29.20002, false, 0.0, 50.0, 0);
            break;
        case oficina_porta:
            mp.game.object.doorControl(mp.game.joaat('v_ilev_cs_door'), 482.911, -1312.584, 29.20103, false, 0.0, 50.0, 0);
            break;
    }
});

mp.events.add('doorLock', (model, position, locked) => {

    try {
        mp.game.object.doorControl(parseInt(model), position.x, position.y, position.z, locked, 1.0, 0.1, 0.0) 


    }
    catch (e) {
        mp.gui.chat.push(model + " " + position.toString() + " " + locked);
    }
    // mp.game.object.setStateOfClosestDoorOfType(model, position.x, position.y, position.z, locked, 0, false);
});

mp.events.add('explode', (position, explosionType, damageScale, isAudible, isInvisible, cameraShake) => {
    mp.game.fire.addExplosion(position.x, position.y, position.z, explosionType, damageScale, isAudible, isInvisible, cameraShake);
});

//
// Login
//
var loginCamera = camerasManager.createCamera('loginCamera', 'default', new mp.Vector3(-436.0717, 1039.26, 372.1287), new mp.Vector3(3.063985, 0.0, -170.8151), 60);


mp.events.add('accountLoginForm', (bool) => {

    if (bool == null) {
        mp.events.call('createBrowser', ['package://files/html/login.html']);

        mp.gui.chat.activate(false);
        mp.gui.chat.safeMode = false;
        mp.gui.chat.colors = true;
        mp.game.graphics.startScreenEffect('SwitchSceneMichael', 5000, false);


        camerasManager.setActiveCamera(loginCamera, true);
        camerasManager.setActiveCameraWithInterp(loginCamera, new mp.Vector3(-508.6306, -267.414, 63.64975), new mp.Vector3(-14, 0, 32), 10000, 0, 0)

        mp.game.ui.displayRadar(false);
        mp.game.gameplay.enableMpDlcMaps(true);
        mp.game.player.disableVehicleRewards();
    }
    else {
        mp.gui.chat.activate(false);
        mp.gui.chat.safeMode = false;
        mp.gui.chat.colors = true;

        mp.game.ui.displayRadar(false);
        mp.game.gameplay.enableMpDlcMaps(true);
        mp.game.player.disableVehicleRewards();
    }
    
    

    /*cam = mp.cameras.new('creatorcamera', new mp.Vector3(-436.0717, 1039.26, 372.1287), new mp.Vector3(3.063985, 0.0, -170.8151), 60);
    cam.setActive(true);
	mp.game.cam.renderScriptCams(true, false, 0, true, false);*/


    /*cam = mp.cameras.new('default', new mp.Vector3(-95, 19, 1182), new mp.Vector3(0, 0, 0), 70);
    cam.pointAtCoord(-95, 19, 0);
    cam.setActive(true);
    mp.game.cam.renderScriptCams(true, false, 0, true, false);*/

    //saveFreemodePosition: 639.2661, 769.7157, 371.4225 - -16, 0, 346.
    //saveFreemodePosition: 710.2661, 1048.216, 360.9225 - -6, 0, 352.

    // about the chat
   

    /*
	mp.game.player.setHealthRechargeMultiplier(0.0);
    mp.game.streaming.requestIpl("ex_dt1_02_office_02b");//-141.1987, -620.913, 168.8205
 mp.gui.chat.activate(false);
    mp.gui.chat.safeMode = false;
    mp.gui.chat.colors = true;


    camerasManager.setActiveCamera(loginCamera, true);
    camerasManager.setActiveCameraWithInterp(loginCamera, new mp.Vector3(-508.6306, -267.414, 63.64975), new mp.Vector3(-14, 0, 32), 10000, 0, 0);

    mp.game.ui.displayRadar(false);
    mp.game.gameplay.enableMpDlcMaps(true);
    mp.game.player.disableVehicleRewards();   mp.game.streaming.requestIpl("ex_dt1_11_office_01c");//-75.47446, -827.2621, 243.386
   	mp.game.streaming.requestIpl("ex_sm_13_office_03c");//-1579.693, -564.8981, 108.5229
   	mp.game.streaming.requestIpl("ex_sm_15_office_03b");//-1392.528, -480.475, 72.04206
   	mp.game.streaming.requestIpl("apa_v_mp_h_01_a");
   	mp.game.streaming.requestIpl("coronertrash");//275.446, -1361.11, 24.5378
   	mp.game.streaming.requestIpl("Coroner_Int_On");
   	mp.game.streaming.requestIpl("farm");//2469.03, 4955.278, 45.11892
   	mp.game.streaming.requestIpl("farm_props");
   	mp.game.streaming.requestIpl("farmint");
   	mp.game.streaming.removeIpl("farmint_cap");
   	mp.game.streaming.removeIpl("CS1_02_cf_offmission");
   	mp.game.streaming.requestIpl("cargoship");
   	mp.game.streaming.removeIpl("facelobbyfake");
   	mp.game.streaming.requestIpl("facelobby");
   	mp.game.streaming.removeIpl("fakeint");
   	mp.game.streaming.requestIpl("shutter_open");
   	mp.game.streaming.requestIpl("shr_int");
   	mp.game.streaming.removeIpl("v_carshowroom");
   	mp.game.streaming.requestIpl("refit_unload");
   	mp.game.streaming.requestIpl("SP1_10_real_interior");
   	mp.game.streaming.requestIpl("FINBANK");//2.6968, -667.0166, 16.13061
   	mp.game.streaming.requestIpl("redCarpet");//300.5927, 300.5927, 104.3776
   	mp.game.streaming.requestIpl("SUNK_SHIP_FIRE");
   	mp.game.streaming.removeIpl("sheriff_cap");
   	mp.game.streaming.removeIpl("SP1_10_fake_interior");
   	mp.game.streaming.removeIpl("CS1_16_Sheriff_Cap");
    	
    mp.game.streaming.requestIpl("imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
   	mp.game.streaming.requestIpl("bkr_bi_hw1_13_int");*/
});


mp.events.add('loginUser', (login_password) => {

    setTimeout(function() {
        // Check for the credentials
        mp.events.callRemote('loginUser', login_password);


    }, 100);
});

mp.events.add('Recovery_Password', (recinfo) => {

    setTimeout(function () {
        mp.events.callRemote('Recovery_Password', recinfo);
    }, 100);
});

mp.events.add('registerUser', (register_password, register_email,ref) => {

    setTimeout(function() {
        // Check for the credentials
        mp.events.callRemote('registerUser', register_password, register_email, ref);


    }, 100);
});

mp.events.add('clearLoginWindow', () => {
    // Unfreeze the player
    mp.players.local.freezePosition(false);

    // Destroy the login window
    mp.events.call('destroyBrowser');

    mp.game.graphics.stopScreenEffect('SwitchSceneMichael');
});

mp.events.add('displayerror', (id,text) => {
    if (customBrowser != undefined) {
        switch (id) {
            case 0:
                customBrowser.execute("displayerror0();");
                break;
            case 1:
                customBrowser.execute("displayerror1(" + text+");");
                break;
            case 2:
                customBrowser.execute("displayerror2();");
                break;
            default:
        }
        
    }
});

/*mp.events.add('displayLoginButton', () => {
	if (customBrowser != undefined) {
        customBrowser.execute("displayLoginButton();");
    }
});

mp.events.add('displayRegisterButton', () => {
	if (customBrowser != undefined) {
        customBrowser.execute("displayRegisterButton();");
    }
});*/

//
// Admin / Camera
//

let spyCamera = mp.cameras.new('default', new mp.Vector3(0.0, 0.0, 0.0), new mp.Vector3(0.0, 0.0, 0.0), 0);

//
//
//saveFreemodePosition: 639.2661, 769.7157, 371.4225 - -16, 0, 346.
//saveFreemodePosition: 710.2661, 1048.216, 360.9225 - -6, 0, 352.

findPlayerByIdOrNickname = function(playerName) {
    let foundPlayer = null;
    if (playerName == parseInt(playerName)) {
        foundPlayer = mp.players.at(playerName);
    }

    if (!foundPlayer) {
        mp.players.forEach((_player) => {
            if (_player.name === playerName) {
                foundPlayer = _player;
            }
        });
    }
    return foundPlayer;
}

mp.events.add({
    'adminSpyPlayer': (targetid) => {
        let target = findPlayerByIdOrNickname(targetid);

        localPlayer.attachTo(target.handle, 0, 0, 0, 0, 0, 0, 0, true, false, false, false, 0, false);

        spyCamera.attachTo(target.handle, 0.0, 0.0, 0.0, true);
        spyCamera.setActive(true);

        mp.game.cam.renderScriptCams(true, false, 0, true, false);
    },
    'adminStopSpy': () => {
        
        localPlayer.detach();
        spyCamera.setActive(false);
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
    }
});

//
// Camera
//

let driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-878.0559, -2081.562, 23.799), new mp.Vector3(-14, 0, 46), 50);

mp.events.add('ShowDMVCamera', (type) => {
    if (type === 1) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-878.0559, -2081.562, 23.799), new mp.Vector3(-14, 0, 46), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-878.0559, -2081.562, 23.799), new mp.Vector3(-14, 0, 46), 30000, 0, 0);
    } else if (type === 2) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(79.85892, -1369.071, 37.84154), new mp.Vector3(-10, 0, 88), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(79.85892, -1369.071, 37.84154), new mp.Vector3(-10, 0, 88), 30000, 0, 0);
    } else if (type === 3) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(-99.26994, -1178.103, 31.79146), new mp.Vector3(-12, 0, -8), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(-99.26994, -1178.103, 31.79146), new mp.Vector3(-12, 0, -8), 30000, 0, 0);
    } else if (type === 4) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(95.80418, -1043.833, 40.31485), new mp.Vector3(-34, 0, -20), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(95.80418, -1043.833, 40.31485), new mp.Vector3(-34, 0, -20), 30000, 0, 0);
    } else if (type === 5) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(396.9243, -989.0579, 33.46381), new mp.Vector3(-12, 0, -90), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(396.9243, -989.0579, 33.46381), new mp.Vector3(-12, 0, -90), 30000, 0, 0);
    } else if (type === 6) {
        camerasManager.destroyCamera(driverLicenseCamera);
        driverLicenseCamera = camerasManager.createCamera('driverLicenseCamera', 'default', new mp.Vector3(2767.7, 3917.981, 69.10294), new mp.Vector3(-10, 0, 34), 50);
        camerasManager.setActiveCamera(driverLicenseCamera, true);
        camerasManager.setActiveCameraWithInterp(driverLicenseCamera, new mp.Vector3(2767.7, 3917.981, 69.10294), new mp.Vector3(-10, 0, 34), 30000, 0, 0);
    } else if (type === 7) {
        camerasManager.destroyCamera(driverLicenseCamera);
        camerasManager.setActiveCamera(driverLicenseCamera, false);
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
    }
});


mp.events.add("PlaySoundFrontend", (audioName, audioLibrary) => {
    mp.game.audio.playSoundFrontend(-1, audioName, audioLibrary, true);
});

//
// Phone System
//

function ringtone(clientID, stop = false) {
    if (ringTone != null) clearInterval(ringTone);
    if (stop) return false;

    ringToneCounter = 0;

    ringTone = setInterval(function() {
        ringToneCounter++;

        if (ringToneCounter < 11) {
            mp.events.call('playSoundFor', clientID, 'On_Call_Player_Join', 'DLC_HEISTS_GENERAL_FRONTEND_SOUNDS');
        }

        if (ringToneCounter > 30) ringToneCounter = 0;
    }, 78);
}

mp.events.add({
    "playSoundFor": (player, sound, dict) => {
        let target = mp.players.atRemoteId(player);

        
    },
    "playSoundFrom": (position, sound, dict) => {
        mp.game.audio.playSoundFromCoord(-1, sound, position.x, position.y, position.z, dict, false, 0, false);
    },
    "playSpeechSoundFor": (playerID, speechName, speechVoice) => {
        let player = mp.players.atRemoteId(playerID);

        if (player) mp.game.playSpeech(player, speechName, speechVoice);
    },
    "playRingtone": (playerID) => {
        let target = mp.players.atRemoteId(playerID);

       
    },
    "playClientSound": (soundName, volume) => {
        if (uiPlayer_Browsers != undefined) {
            volume = Math.round(volume * 10) / 10;

            uiPlayer_Browsers.execute(`playAudio('${soundName}', '${volume}');`);
        }
    },
    "StopClientSound": () => {
        if (uiPlayer_Browsers != undefined) {

            uiPlayer_Browsers.execute(`stopaudio();`);
        }
    },
    
    "initPhone": () => {
        if (phone === undefined) {

            phone = mp.browsers.new("package://files/celular/index.html");

            //phone.execute(`initApps('${apps}');`);
            phone.execute(`setPhoneNumber('${phoneNumber}');`);
            //phone.execute(`startTime('${timeNow}')`);

            //mp.gui.chat.push('initPhone');




            /*phoneContacts.forEach((contact) => {
            	let con = JSON.stringify(contact);

            	phone.execute(`addContact('${con}');`);
            });*/
        } else {
            phone.execute(`setPhoneNumber('${phoneNumber}');`);
        }
    },
    "destroyPhone": () => {
        if (phone != undefined) {
            phone.destroy();
            phone = undefined;
        }
    },
    "openPhone": (code) => {
		
        if (phone != undefined) {
            phone.execute(`togglePhone(true)`);

            phone_menu = true;
             if(code == false)
			 {
            mp.gui.cursor.visible = true;
            cursor_status = true;
			 }
        }
		
    },
    "closePhone": () => {
        if (phone != undefined) {
            //phone = false;
            //mp.gui.chat.push('closePhone');
            phone_menu = false;

            mp.gui.cursor.visible = false;
            cursor_status = false;

            phone.execute(`togglePhone(false)`);
        }
    },
    "togglePhone": (forcefully = false) => {
        isPhone = false;
        phone.execute(`closeApp();`);
    },
    "setPhoneNumber": (number) => {
        //mp.gui.chat.push('setPhoneNumber');
        phoneNumber = number;

        if (phone) phone.execute(`setPhoneNumber('${phoneNumber}');`);
    },
    "Update_Contacts": (contact) => {
        //mp.gui.chat.push('setPhoneNumber');

        if (phone) phone.execute(`loadContacts('${contact}');`);
    },
    "startCall": (number) => {

        mp.events.callRemote('dialingNumber', number);
        /*mp.events.call('playClientSound', 'chamando', 0.2);

         dialInterval = setInterval(function() {
            mp.events.call('playClientSound', 'chamando', 0.2);
         }, 4630);*/
    },

    "request_sms": (number) => {
        mp.events.callRemote('Update_SMS', number);
    },

    "request_sms_list": () => {
        mp.events.callRemote('Show_SMS');
    },
    "requestinfo": () => {
        mp.events.callRemote('req_info');
    },
    

    "Send_SMS": (number, texto) => {
        mp.events.callRemote('Send_SMS_SERVER', number, texto);
    },

    "Remove_Contact": (number) => {
        mp.events.callRemote('onClientRequestRemovePlayerContact', number);
    },

    "Update_SMS_Web": (sms) => {
        //mp.gui.chat.push('setPhoneNumber');

        if (phone) phone.execute(`Load_SMS('${sms}');`);
    },

    "Update_SMS_List": (sms) => {
        //mp.gui.chat.push('setPhoneNumber');

        if (phone) phone.execute(`loadSMSList('${sms}');`);
    },

    /*"Update_SMS": (sms) => {

        if (phone) phone.execute(`Load_SMS('${sms}');`);
    },*/


    "addContact": (number, name) => {
        mp.events.callRemote('Add_Contact', number, name);
    },
    "incomingCall": (caller, number) => {
        incomingCaller = caller;
        phone.execute(`callIncoming('${number}')`);
        //mp.gui.chat.push('incomingCall');
    },
    "startApp": (name) => {
        phone.execute(`startApp('${name}')`);
        //mp.gui.chat.push('incomingCall');
    },
    "cancelCall": () => {
        //mp.gui.chat.push('cancelCall');
        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        if (incomingCaller != null) {
            incomingCaller.isInCallWith = null;
            incomingCaller = null;
        }

        mp.events.callRemote('cancelCallingNumber');
    },
    "denyCall": () => {
        //mp.gui.chat.push('denyCall');
        phone.execute(`cancelCall()`);

        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        mp.events.call('playClientSound', 'chamada_recusada', 0.2);
    },
    "acceptIncomingCall": (number) => {
        //mp.gui.chat.push('acceptIncomingCall');
        incomingCaller.isInCallWith = mp.players.local;
        mp.events.callRemote('acceptCall', number);
    },
    "incomingCallFor": (playerID) => {
        //mp.gui.chat.push('incomingCallFor');
        let player = mp.players.atRemoteId(playerID);

        if (player) {
            ringtone(playerID);
        }
    },
    "callAcceptFor": (playerID) => {
        //mp.gui.chat.push('callAcceptFor');
        let player = mp.players.atRemoteId(playerID);

        if (player) ringtone(playerID, true);
    },
    "callDeniedFor": (playerID) => {
        //mp.gui.chat.push('callDeniedFor');
        let player = mp.players.atRemoteId(playerID);

        if (player) ringtone(playerID, true);
        if (player == mp.players.local) phone.execute(`cancelCall()`);
    },
    "callAccepted": (caller, number) => {

        //Voice.add(caller, true);
        //mp.events.call('voice.phoneCall', caller);

        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        phone.execute(`setCallScreen('${number}', 0, true)`);
        //mp.gui.chat.push('callAccepted -- ' + caller + ' ' + number + '');
    },
    "callEnded": (caller = null) => {

        //if(caller) Voice.remove(caller, true);
        //mp.events.call('voice.phoneStop');

        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        if (incomingCaller != null) {
            incomingCaller.isInCallWith = null;
            incomingCaller = null;
        }

        phone.execute(`cancelCall('true')`);

        //mp.gui.chat.push('callEnded -- ' + caller + '');
    },
    "closeApp": () => {
        if (phone && phone != false) {
            phone_app = false;
            phone_app_loaded = false;

            phone.execute(`closeApp();`);
            if (dialInterval != null) {
                clearInterval(dialInterval);
                dialInterval = null;
            }
        }
    },
    "removeNumber": () => {
        phone.execute(`removeNumber();`);
    },
    
    "callNumber": (number) => {
        mp.events.callRemote('dialNumber', number);
    },
    "removeSound": () => {
        mp.game.audio.playSoundFromEntity(-1, "ERROR", mp.players.local.handle, "HUD_FRONTEND_CLOTHESSHOP_SOUNDSET", true, 0);
    },
    "typeWords": () => {
        mp.game.audio.playSoundFromEntity(-1, "EDIT", mp.players.local.handle, "HUD_DEATHMATCH_SOUNDSET", true, 0);
    },
    "processFail": () => {
        mp.game.audio.playSoundFromEntity(-1, "Pin_Bad", mp.players.local.handle, "DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS", true, 0);
    },
    "processSuccess": () => {
        mp.game.audio.playSoundFromEntity(-1, "Pin_Good", mp.players.local.handle, "DLC_HEIST_BIOLAB_PREP_HACKING_SOUNDS", true, 0);
    },
    "helmetFalse": () => {
		mp.players.local.setHelmet(false);
    },

    "service_accept": (number) => {

        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        phone.execute(`setCallScreen('${number}', 0, true)`);
    },
    "service_cancel": () => {

        if (dialInterval != null) {
            clearInterval(dialInterval);
            dialInterval = null;
        }

        if (incomingCaller != null) {
            incomingCaller.isInCallWith = null;
            incomingCaller = null;
        }

        phone.execute(`cancelCall('true')`);
    },
});



const Natives2 = {
    SWITCH_OUT_PLAYER: '0xAAB3200ED59016BC',
    SWITCH_IN_PLAYER: '0xD8295AF639FD9CB8',
    IS_PLAYER_SWITCH_IN_PROGRESS: '0xD9D2CFFF49FAB35F'
};
let gui;



		
mp.events.add('moveSkyCamera', moveFromToAir);

function moveFromToAir(player, moveTo, switchType, showGui) {   
    
     /*   switchType: 0 - 3

        0: 1 step towards ped
        1: 3 steps out from ped (Recommended)
        2: 1 step out from ped
        3: 1 step towards ped*/
   
   switch (moveTo) {
       case 'up':
            if (showGui == false) {
                mp.gui.chat.show(showGui);
                gui = 'false';
            };
            mp.game.invoke(Natives2.SWITCH_OUT_PLAYER, player.handle, 0, parseInt(switchType));
           break;
       case 'down':
            if (gui == 'false') {
                checkCamInAir();
            };
            mp.game.invoke(Natives2.SWITCH_IN_PLAYER, player.handle);
           break;
   
       default:
           break;
   }
}



// Checks whether the camera is in the air. If so, then reset the timer
function checkCamInAir() {
    if (mp.game.invoke(Natives2.IS_PLAYER_SWITCH_IN_PROGRESS)) {
        setTimeout(() => {
            checkCamInAir();
        }, 400);
    } else {
        mp.gui.chat.show(true);
        gui = 'true';
    }
}



/*mp.events.add("testentitysound", (state) => {


    mp.game.audio.playPoliceReport(state, 0);
    mp.gui.chat.push(Siren.Test + " " + state);
        Siren.Test2 = true;
});*/


mp.events.add("SetWalkStyle", (player, walkstyle) => {
    
    player.resetStrafeClipset();
    player.resetMovementClipset(0.5);
    //mp.game.streaming.requestClipSet(walkstyle);
    player.setMovementClipset(walkstyle, 0.5);
    if (walkstyle == "move_ped_crouched") {
       // mp.game.streaming.requestClipSet("move_ped_crouched_strafing");
        player.setStrafeClipset("move_ped_crouched_strafing");
    }
});
var lastpos;

mp.events.addDataHandler("Injured", (entity, value) => {
    if (value == 1 && entity == localPlayer) {
        lastpos = localPlayer.position.z.toFixed(1);
        var git = setInterval(function () {
            if (localPlayer.getVariable('Injured') != 1) {
                clearInterval(git);
            }
            if (localPlayer.position.z.toFixed(1) == lastpos) {
                mp.events.callRemote("SetFullyInjured");
                clearInterval(git);
            }
            else {
                lastpos = localPlayer.position.z.toFixed(1);
            }
        }, 2000);
    }
    else if (value == 2 || value == 0) {
                
    }
   
});


mp.events.add("ForeachFreezeVeh", (vehicle,stats) => {
if (vehicle != undefined)
{
	vehicle.freezePosition(stats);

}
});

mp.events.addDataHandler("isadmininvicible", (entity, value, oldValue) => {
    entity.setInvincible(value);
});

mp.events.addDataHandler("Invicible_Admin", (entity, value) => {
    entity.setInvincible(value);
});


mp.events.add('syncHorn', (vehicle, playing, sound, id) => {
    mp.gui.chat.push("Sync Horn: "+playing+" "+id);
    if (true) {

    }
    if (!playing) {
        mp.game.invoke('0xA3B0C41BA5CC0BB5', id)
    } else {
        mp.game.audio.playSoundFromEntity(id, sound, vehicle.handle, '', true, 0)
    }


})


mp.events.addDataHandler("SirenLight", (entity, value) => {
    if (entity.type === "vehicle") {
        entity.setSiren(!value);
    }
    
});

mp.events.addDataHandler("SirenSound", (entity, value) => {
    if (entity.type === "vehicle") {
        entity.setSirenSound(!value);
    }
    
});



mp.events.add("entityStreamIn", (entity) => {
    if (entity.type === "player")
    {
        if (entity.getVariable("walkstyle") != null) {
            entity.setMovementClipset(entity.getVariable("walkstyle"), 0)
        }
    }
    if(entity.type === "vehicle")
    {
           
        if (entity.getVariable("VehFreezed") == true) {
            entity.freezePosition(true)
        }
        if (entity.getClass == 18) {
            if (entity.getVariable("SirenLight") == true) {
                entity.setSiren(true)
            } else if (entity.getVariable("SirenLight") == false) {
                entity.setSiren(false)
            }

            if (entity.getVariable("SirenSound") == true) {
                entity.setSirenSound(false)
            } else if (entity.getVariable("SirenSound") == false){
                entity.setSirenSound(true)
            }
        }
            
    }
});

// C key 
mp.keys.bind(0x43, false, () => {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    mp.events.callRemote("toggleCrouch");
});



////f g
mp.events.add('pressgkey', () => {
    const localPlayer = mp.players.local;
    if (localPlayer.vehicle === null) {
        let found = false;

        mp.vehicles.forEachInStreamRange((vehicle) => {
            const dist = distanceTo(localPlayer.position, vehicle.position);
            if (!found && (localPlayer.isOnSpecificVehicle(vehicle.handle) || dist < 4 && vehicle.getSpeed() < 5 && localPlayer.getVariable("Injured") == 0)) {
                found = true;
                let seat_pside_r = vehicle.getWorldPositionOfBone(vehicle.getBoneIndexByName("seat_pside_r"));
                let seat_pside_f = vehicle.getWorldPositionOfBone(vehicle.getBoneIndexByName("seat_pside_f"));
                let seat_dside_r = vehicle.getWorldPositionOfBone(vehicle.getBoneIndexByName("seat_dside_r"));
                let door_pside_r = vehicle.getWorldPositionOfBone(vehicle.getBoneIndexByName("door_pside_r"));
                let seat_r = vehicle.getWorldPositionOfBone(vehicle.getBoneIndexByName("seat_r"));
                let playerPos = mp.players.local.position;
                let distance = calcDist(playerPos, seat_pside_r);
                let seat = 0;

                if (vehicle.isSeatFree(0) && calcDist(playerPos, seat_pside_f) < distance) {
                    distance = calcDist(playerPos, seat_pside_f);
                    seat = 0;
                }
                if (vehicle.isSeatFree(1) && calcDist(playerPos, seat_dside_r) < distance) {
                    distance = calcDist(playerPos, seat_dside_r);
                    seat = 1;
                }
                if (vehicle.isSeatFree(2) && calcDist(playerPos, door_pside_r) < distance) {
                    distance = calcDist(playerPos, seat_dside_r);
                    seat = 2;
                }
                if (vehicle.isSeatFree(3) && calcDist(playerPos, seat_r) < distance) {
                    seat = 3;

                } if (vehicle.isSeatFree(4) && calcDist(playerPos, seat_r) < distance) {
                    seat = 4;
                }
                
                if (vehicle.model == 0x1517D4D9) {
                    if (vehicle.isSeatFree(2) && calcDist(playerPos, seat_pside_r) < calcDist(playerPos, seat_pside_f)  ) {
                        seat = 2;
                    }
                }
                if (vehicle.isSeatFree(seat)) {
                    localPlayer.taskEnterVehicle(vehicle.handle, 5000, seat, 2.0, 1, 0);
                   // mp.gui.chat.push(calcDist(playerPos, seat_pside_f) + " " + seat);
                    return;
                }

            }

        });
    }
});

mp.events.add('StartFire', (posX, posY, posZ, maxChildren, isGasFire) => {
    // The fireId is a int
    let fireId = mp.game.fire.startScriptFire(posX, posY, posZ, maxChildren, isGasFire);
});


let updatetimer = undefined;
mp.events.add('FiresAliveTimer', (posX, posY, posZ) => {
    
    xPos = posX;
    yPos = posY;
    zPos = posZ;
    firesAlive = mp.game.fire.getNumberOfFiresInRange(xPos, yPos, zPos, 25);
    updatetimer = setInterval(myTimer, 1000);

});



mp.events.add('UpdateAutoPilotSpeed', (speed) => {
    autoPilotSpeed = speed;
});

mp.events.add('updateautopilotbehavior', (behave) => {
    autoPilotBehavior = behave;
});

mp.events.addDataHandler("PlayAnimationwithtime", (entity, value) => {
    if (entity.type === "player") {
        mp.game.streaming.requestAnimDict(value[0].animdictionary);

        entity.taskPlayAnim(value[0].animdictionary, value[0].animationName, value[0].Blendinspeed, value[0].blendoutspeed, value[0].duration, value[0].flag, 0, false, false, false);
    }
});

var autopilotStart = !1,
    autopilotPoint = null,
    autopilotInterval = null;
let autoPilotSpeed = 35;
let autoPilotBehavior = 2883621;

mp.events.add('autopilotvip', () => {
    if (logged === 0 || chatopened || uiGlobal_Browsers != undefined || uiGeneralStart_Browsers != undefined || phone_menu === true || menu_libary === true || new Date().getTime() - lastCheck < 100) return;
    lastCheck = new Date().getTime();
    const a = localplayer.vehicle;
    if (localplayer.vehicle.getPedInSeat(-1) !== localplayer.handle) return;
    if (autopilotStart) {
        const a = localplayer.vehicle;
        return a && (localplayer.clearTasks(), localplayer.taskVehicleTempAction(a.handle, 27, 1e4)), autopilotPoint = null, autopilotStart = !1, void clearInterval(autopilotInterval)
    }
    if (null == a) return;

    //  var vehicleName = a.getModel();
    //  mp.gui.chat.push(`vehname: ${vehicleName}`);

    //   var engine = a.getIsEngineRunning();
    // if (engine == false) return mp.game.graphics.notify('Turn On The Engine.');  

    let b = mp.game.invoke("0x1DD1F58F493F1DA5"),
        c = mp.game.invoke("0x186E5D252FA50E7D"),
        d = mp.game.invoke("0x1BEDE233E6CD2A1F", c),
        e = mp.game.invoke("0x14F96AA50D6FBEA7", c);

    for (let a = d; 0 != mp.game.invoke("0xA6DB27D19ECBB7DA", a); a = e)
        if (4 == mp.game.invoke("0xBE9B0959FFD0779B", a) && !!b) {
            autopilotPoint = mp.game.ui.getBlipInfoIdCoord(a);
            break
        }
    return null == autopilotPoint ? void mp.game.graphics.notify("Autopilot: Morate oznaciti mesto na mapi.") : void (!autopilotStart && (mp.game.graphics.notify("Autopilot: Mesto oznaceno. Autopilot aktiviran."), localplayer.taskVehicleDriveToCoord(a.handle, autopilotPoint.x, autopilotPoint.y, autopilotPoint.z, autoPilotSpeed, 1, 1, autoPilotBehavior, 30, 1), autopilotStart = !0, clearInterval(autopilotInterval), autopilotInterval = setInterval(() => {
        if (!autopilotStart) return void clearInterval(autopilotInterval);
        const a = localplayer.vehicle;
        return a ? 15 > mp.game.system.vdist(localplayer.position.x, localplayer.position.y, localplayer.position.z, autopilotPoint.x, autopilotPoint.y, autopilotPoint.z) ? (localplayer.clearTasks(), a && localplayer.taskVehicleTempAction(a.handle, 27, 1e4), autopilotPoint = null, autopilotStart = !1, clearInterval(autopilotInterval), void mp.game.graphics.notify("Autopilot: Stigli ste na zeljenu destinaciju!")) : void 0 : (a && (localplayer.clearTasks(), localplayer.taskVehicleTempAction(a.handle, 27, 1e4)), autopilotStart = !1, void clearInterval(autopilotInterval))
    }, 300)))
});

function distanceTo(vec1, vec2) {
    return Math.hypot(vec2.x - vec1.x, vec2.y - vec1.y, vec2.z - vec1.z);
}

mp.events.add('radiooff', (vehicle, seat) => {
    setTimeout(() => {
        mp.game.audio.setRadioToStationName("OFF");
    }, 1000);
});

