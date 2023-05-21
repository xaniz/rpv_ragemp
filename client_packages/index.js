global.chatopened = false;
global.isChat = false;
global.logged = 0;

//
require('./static-attachments');
require('files/index.js');
require('files/furniture.js');
require('files/fly.js');
require('files/fly.js');
require('ped.js');
require('circle.js');
require('client.js');
require('heistisland.js');

require('./CircuitBreaker');






//require("MapEditor/MapEditor.js");
//require("MapEditor/object_data.js");
//require("MapEditor/Natives.js");


const bones = ['door_dside_f', 'door_pside_f', 'door_dside_r', 'door_pside_r'];
const names = ['door', 'door', 'door', 'door'];
let target = null;

const getClosestBone = (raycast) => {
    let data = [];
    bones.forEach((bone, index) => {
        const boneIndex = raycast.entity.getBoneIndexByName(bone);
        const bonePos = raycast.entity.getWorldPositionOfBone(boneIndex);
        if(bonePos) {
            data.push({
                    id: index, 
                    boneIndex: boneIndex, 
                    name: bone, 
                    bonePos: bonePos, 
                    locked: !raycast.entity.doors[index] || !raycast.entity.doors[index] && !raycast.entity.isDoorFullyOpen(index) ? false : true, 
                    raycast: raycast,
                    veh: raycast.entity, 
                    distance: mp.game.gameplay.getDistanceBetweenCoords(bonePos.x, bonePos.y, bonePos.z, raycast.position.x, raycast.position.y, raycast.position.z, false),
                    pushTime: Date.now()/1000
            });
        }
    })

    return data.sort((a,b) => a.distance-b.distance)[0];
}

const getLocalTargetVehicle = (range = 2.0) => {
    let startPosition = mp.players.local.getBoneCoords(12844, 0.5, 0, 0);
    const res = mp.game.graphics.getScreenActiveResolution(1, 1);
    const secondPoint = mp.game.graphics.screen2dToWorld3d([res.x / 2, res.y / 2, (2 | 4 | 8)]);
    if(!secondPoint) return null;

    startPosition.z -= 0.3;
    const target = mp.raycasting.testPointToPoint(startPosition, secondPoint, mp.players.local, (2 | 4 | 8 | 16));

    if(target && target.entity.type === 'vehicle' && mp.game.gameplay.getDistanceBetweenCoords(target.entity.position.x, target.entity.position.y, target.entity.position.z, mp.players.local.position.x, mp.players.local.position.y, mp.players.local.position.z, false) < range) return target;
    return null;
}

const drawTarget3d = (pos, textureDict = "mpmissmarkers256", textureName = "corona_shade", scaleX = 0.005, scaleY = 0.01) => {
    const position = mp.game.graphics.world3dToScreen2d(pos);
    if(!position) return;
    mp.game.graphics.drawSprite(textureDict, textureName, position.x, position.y, scaleX, scaleY, 0, 0, 0, 0, 200);
}

mp.events.add({
    'render' : () => {
        if(!mp.players.local.vehicle && !mp.gui.cursor.visible) {
            const raycast = getLocalTargetVehicle();

            if(raycast && raycast.entity.getDoorLockStatus() == 1 && raycast.entity.doors && raycast.entity.getClass() !== 13 && raycast.entity.getClass() !== 8 && !mp.game.player.isFreeAiming() && mp.game.gameplay.getDistanceBetweenCoords(raycast.entity.position.x, raycast.entity.position.y, raycast.entity.position.z, mp.players.local.position.x, mp.players.local.position.y, mp.players.local.position.z, false) < 1.5) {
    
                target = getClosestBone(raycast);
                if(!target) return;

                drawTarget3d(target.raycast.position);
                mp.game.graphics.drawText(`${target.id}. ${target.locked ? 'Close' : 'Open'} ${names[target.id]}`, [target.raycast.position.x, target.raycast.position.y, target.raycast.position.z], { 
                    font: 0, 
                    color: [255, 255, 255, 255], 
                    scale: [0.2, 0.2], 
                    centre: true
                });
            }
        }
    },
    
});

mp.keys.bind(69, true, () => {
    if(!mp.gui.cursor.visible && target && target.pushTime + 1 >= Date.now()/1000 && target.veh.doesExist()) {
        target.veh.doors[target.id] = ! target.veh.doors[target.id];
        mp.events.callRemote('server.vehicles.sync.doors', target.veh, JSON.stringify(target.veh.doors));
    }
});

	




// Better notification

const _SET_NOTIFICATION_COLOR_NEXT = "0xf92b835a141c6bdd";
const _SET_NOTIFICATION_BACKGROUND_COLOR = "0xa633a5db2d269825";
const maxStringLength = 99;

mp.events.add("BN_Show", (message, flashing = false, textColor = -1, bgColor = -1, flashColor = [77, 77, 77, 200]) => {
    if (textColor > -1) mp.game.invoke(_SET_NOTIFICATION_COLOR_NEXT, textColor);
    if (bgColor > -1) mp.game.invoke(_SET_NOTIFICATION_BACKGROUND_COLOR, bgColor);
    if (flashing) mp.game.ui.setNotificationFlashColor(flashColor[0], flashColor[1], flashColor[2], flashColor[3]);

    mp.game.ui.setNotificationTextEntry("CELL_EMAIL_BCON");
    for (let i = 0, msgLen = message.length; i < msgLen; i += maxStringLength) mp.game.ui.addTextComponentSubstringPlayerName(message.substr(i, Math.min(maxStringLength, message.length - i)));
    mp.game.ui.drawNotification(flashing, true);
});

mp.events.add("BN_ShowWithPicture", (title, sender, message, notifPic, icon = 0, flashing = false, textColor = -1, bgColor = -1, flashColor = [77, 77, 77, 200]) => {
    if (textColor > -1) mp.game.invoke(_SET_NOTIFICATION_COLOR_NEXT, textColor);
    if (bgColor > -1) mp.game.invoke(_SET_NOTIFICATION_BACKGROUND_COLOR, bgColor);
    if (flashing) mp.game.ui.setNotificationFlashColor(flashColor[0], flashColor[1], flashColor[2], flashColor[3]);

    mp.game.ui.setNotificationTextEntry("CELL_EMAIL_BCON");
    for (let i = 0, msgLen = message.length; i < msgLen; i += maxStringLength) mp.game.ui.addTextComponentSubstringPlayerName(message.substr(i, Math.min(maxStringLength, message.length - i)));
    mp.game.ui.setNotificationMessage(notifPic, notifPic, flashing, icon, title, sender);
    mp.game.ui.drawNotification(false, true);
});

mp.game.ui.notifications = {
    show: (message, flashing = false, textColor = -1, bgColor = -1, flashColor = [77, 77, 77, 200]) => mp.events.call("BN_Show", message, flashing, textColor, bgColor, flashColor),
    showWithPicture: (title, sender, message, notifPic, icon = 0, flashing = false, textColor = -1, bgColor = -1, flashColor = [77, 77, 77, 200]) => mp.events.call("BN_ShowWithPicture", title, sender, message, notifPic, icon, flashing, textColor, bgColor, flashColor)
};

mp.game.streaming.requestIpl('canyonrvrdeep');
mp.game.streaming.requestIpl('canyonrvrshallow');
mp.game.streaming.requestIpl("vw_casino_main");

mp.game.interior.enableInteriorProp(255233, 'floor_vinyl_08');
mp.game.interior.refreshInterior(255233);

//Clubhouse 1
//1107.04, -3157.399, -37.51859
//mp.game.streaming.requestIpl
mp.game.streaming.requestIpl('bkr_biker_interior_placement_interior_0_biker_dlc_int_01_milo');
mp.game.interior.enableInteriorProp(246273, 'Walls_02');
mp.game.interior.enableInteriorProp(246273, 'Furnishings_02');
mp.game.interior.enableInteriorProp(246273, 'Decorative_02');
mp.game.interior.enableInteriorProp(246273, 'Mural_09');
mp.game.interior.enableInteriorProp(246273, 'NO_MOD_BOOTH');
mp.game.interior.enableInteriorProp(246273, 'Gun_Locker');
mp.game.interior.enableInteriorProp(246273, 'Cash_stash3');
mp.game.interior.enableInteriorProp(246273, 'Weed_stash3');
mp.game.interior.enableInteriorProp(246273, 'meth_stash3');
mp.game.interior.enableInteriorProp(246273, 'counterfeit_stash3');
mp.game.interior.refreshInterior(246273);

//clubhouse2
//998.4809, -3164.711, -38.90733
mp.game.streaming.requestIpl('bkr_biker_interior_placement_interior_0_biker_dlc_int_02_milo');
//mp.game.invoke('0x8D8338B92AD18ED6', 246529, 'lower_walls_default', 1);
mp.game.interior.enableInteriorProp(246529, 'Walls_01');
mp.game.interior.enableInteriorProp(246529, 'lower_walls_default');
mp.game.interior.enableInteriorProp(246529, 'Furnishings_01');
mp.game.interior.enableInteriorProp(246529, 'Decorative_01');
mp.game.interior.enableInteriorProp(246529, 'Mural_01');
mp.game.interior.enableInteriorProp(246529, 'NO_MOD_BOOTH');
mp.game.interior.enableInteriorProp(246529, 'Gun_Locker');
mp.game.interior.enableInteriorProp(246529, 'Cash_medium');
mp.game.interior.enableInteriorProp(246529, 'Weed_large');
mp.game.interior.enableInteriorProp(246529, 'counterfeit_large');
mp.game.interior.enableInteriorProp(246529, 'id_medium');
mp.game.interior.refreshInterior(246529);

//bunker
//899.5518,-3246.038, -98.04907
mp.game.interior.enableInteriorProp(258561, 'bunker_style_c');
mp.game.interior.enableInteriorProp(258561, 'upgrade_bunker_set');
mp.game.interior.enableInteriorProp(258561, 'security_upgrade');
mp.game.interior.enableInteriorProp(258561, 'office_upgrade_set');
mp.game.interior.enableInteriorProp(258561, 'gun_locker_upgrade');
mp.game.interior.enableInteriorProp(258561, 'gun_range_lights');
mp.game.interior.enableInteriorProp(258561, 'Gun_schematic_set');
mp.game.interior.refreshInterior(258561);

//vehicle warehouse
//994.5925, -3002.594, -39.64699
//mp.game.streaming.requestIpl("imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
//mp.game.interior.enableInteriorProp(252673, "urban_style_set");
//mp.game.interior.enableInteriorProp(252673, "car_floor_hatch");
//mp.game.interior.refreshInterior(252673);

// Methlab
//1009.5, -3196.6, -38.99682
mp.game.streaming.requestIpl('bkr_biker_interior_placement_interior_2_biker_dlc_int_ware01_milo');
mp.game.interior.enableInteriorProp(247041, 'meth_lab_production');
mp.game.interior.enableInteriorProp(247041, 'meth_lab_upgrade');
mp.game.interior.enableInteriorProp(247041, 'meth_lab_security_high');
mp.game.interior.enableInteriorProp(247041, 'meth_lab_setup');
mp.game.interior.refreshInterior(247041);

//Weed Farm
//1051.491, -3196.536, -39.14842
//Interior ID: 247297
mp.game.streaming.requestIpl('bkr_biker_interior_placement_interior_3_biker_dlc_int_ware02_milo');
mp.game.interior.enableInteriorProp(247297, 'weed_security_upgrade');
mp.game.interior.enableInteriorProp(247297, 'weed_upgrade_equip');
mp.game.interior.enableInteriorProp(247297, 'weed_chairs');
mp.game.interior.enableInteriorProp(247297, 'weed_production');
mp.game.interior.enableInteriorProp(247297, 'weed_set_up');
mp.game.interior.enableInteriorProp(247297, 'weed_hosei');
mp.game.interior.refreshInterior(247297);

//Counterfeit Cash Factory
//new Vector3(1121.897, -3195.338, -40.4025);
mp.game.streaming.requestIpl('bkr_biker_interior_placement_interior_5_biker_dlc_int_ware04_milo');
mp.game.interior.enableInteriorProp(247809, 'counterfeit_upgrade_equip');
mp.game.interior.enableInteriorProp(247809, 'counterfeit_security');
mp.game.interior.enableInteriorProp(247809, 'money_cutter');
mp.game.interior.enableInteriorProp(247809, 'special_chairs');
mp.game.interior.enableInteriorProp(247809, 'dryera_on');
mp.game.interior.enableInteriorProp(247809, 'counterfeit_cashpile100d');
mp.game.interior.refreshInterior(247809);

//Document Forgery Office ?
//1165, -3196.6, -39.01306
mp.game.streaming.requestIpl('bkr_biker_interior_placement_interior_6_biker_dlc_int_ware05_milo');
mp.game.interior.enableInteriorProp(246785, 'set_up');
mp.game.interior.enableInteriorProp(246785, 'production');
mp.game.interior.enableInteriorProp(246785, 'clutter');
mp.game.interior.enableInteriorProp(246785, 'equipment_upgrade');
mp.game.interior.enableInteriorProp(246785, 'interior_upgrade');
mp.game.interior.enableInteriorProp(246785, 'chair01');
mp.game.interior.enableInteriorProp(246785, 'chair02');
mp.game.interior.enableInteriorProp(246785, 'chair03');
mp.game.interior.enableInteriorProp(246785, 'chair04');
mp.game.interior.enableInteriorProp(246785, 'chair05');
mp.game.interior.enableInteriorProp(246785, 'chair06');
mp.game.interior.enableInteriorProp(246785, 'chair07');
mp.game.interior.refreshInterior(246785);

//Smuggler's Run Hangar
//-1266.802, -3014.837, -49.000
mp.game.interior.enableInteriorProp(260353, 'set_tint_shell');
mp.game.interior.enableInteriorProp(260353, 'set_bedroom_tint');
mp.game.interior.enableInteriorProp(260353, 'set_lighting_tint_props');
mp.game.interior.enableInteriorProp(260353, 'set_modarea');
mp.game.interior.enableInteriorProp(260353, 'set_office_traditional');
mp.game.interior.enableInteriorProp(260353, 'set_bedroom_traditional');
mp.game.interior.enableInteriorProp(260353, 'set_bedroom_blinds_open');
mp.game.interior.enableInteriorProp(260353, 'set_floor_2');
mp.game.interior.enableInteriorProp(260353, 'set_floor_decal_7');
mp.game.interior.enableInteriorProp(260353, 'set_lighting_wall_tint09');
mp.game.interior.enableInteriorProp(260353, 'set_lighting_hangar_a');
mp.game.interior.enableInteriorProp(260353, 'set_crane_tint');
mp.game.interior.refreshInterior(260353);

//Facility
//345.0041, 4842.001, -59.9997
mp.game.interior.enableInteriorProp(269313, 'set_int_02_shell');
//mp.game.invoke('0x8D8338B92AD18ED6', 269313, 'set_int_02_shell', 1);
mp.game.interior.enableInteriorProp(269313, 'set_int_02_lounge2');
//mp.game.invoke('0x8D8338B92AD18ED6', 269313, 'set_int_02_lounge2', 1);
mp.game.interior.enableInteriorProp(269313, 'set_int_02_sleep2');
//mp.game.invoke('0x8D8338B92AD18ED6', 269313, 'set_int_02_sleep2', 1);
mp.game.interior.enableInteriorProp(269313, 'set_int_02_security');
//mp.game.invoke('0x8D8338B92AD18ED6', 269313, 'set_int_02_security', 1);
mp.game.interior.enableInteriorProp(269313, 'set_int_02_cannon');
//mp.game.invoke('0x8D8338B92AD18ED6', 269313, 'set_int_02_cannon', 1);
mp.game.interior.enableInteriorProp(269313, 'set_int_02_decal_03');
//mp.game.invoke('0x8D8338B92AD18ED6', 269313, 'set_int_02_decal_03', 1);
mp.game.interior.enableInteriorProp(269313, 'set_int_02_trophy1');
mp.game.interior.enableInteriorProp(269313, 'Set_Int_02_Parts_Panther1');
mp.game.interior.enableInteriorProp(269313, 'Set_Int_02_Parts_Riot2');
mp.game.interior.enableInteriorProp(269313, 'Set_Int_02_Parts_Cheno1');
mp.game.interior.enableInteriorProp(269313, 'Set_Int_02_Parts_Avenger3');
mp.game.interior.enableInteriorProp(269313, 'set_int_02_paramedic_complete');
mp.game.interior.enableInteriorProp(269313, 'set_int_02_forcedentry_complete');
mp.game.interior.enableInteriorProp(269313, 'set_int_02_aqualungs_complete');
mp.game.interior.enableInteriorProp(269313, 'set_int_02_burglary_complete');
mp.game.interior.enableInteriorProp(269313, 'set_int_02_flightrecord_complete');
mp.game.interior.refreshInterior(269313);

//Avenger Interior
//520.0, 4750.0, -70.0
mp.game.interior.enableInteriorProp(262145, 'shell_tint');
mp.game.interior.enableInteriorProp(262145, 'control_3');
mp.game.interior.enableInteriorProp(262145, 'weapons_mod');
mp.game.interior.enableInteriorProp(262145, 'vehicle_mod');
mp.game.interior.enableInteriorProp(262145, 'gold_bling');
mp.game.interior.refreshInterior(262145);

//Nightclub
//-1604.664, -3012.583, -78.000
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_security_upgrade');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_Style03');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_style03_podium');
mp.game.interior.enableInteriorProp(271617, 'int01_ba_lights_screen');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_Screen');
mp.game.interior.enableInteriorProp(271617, 'DJ_01_Lights_01');
mp.game.interior.enableInteriorProp(271617, 'DJ_02_Lights_02');
mp.game.interior.enableInteriorProp(271617, 'DJ_03_Lights_03');
mp.game.interior.enableInteriorProp(271617, 'DJ_04_Lights_04');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_equipment_upgrade');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_clubname_07');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_dj03');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_lightgrid_01');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_Screen');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_bar_content');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_booze_02');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_dry_ice');
mp.game.interior.enableInteriorProp(271617, 'Int01_ba_trophy07');
mp.game.interior.refreshInterior(271617);

//Nightclub Warehouse
//-1505.783, -3012.587, -80.000
//disableInteriorProp
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_floor01');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_FanBlocker01');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_equipment_upgrade');
mp.game.interior.disableInteriorProp(271873, 'Int02_ba_sec_upgrade_grg');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_sec_upgrade_strg');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_sec_upgrade_desk?');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Cash_EQP');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_coke_EQP');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged_EQP');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed_EQP');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_DeskPC');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_sec_upgrade_desk02');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_clutterstuff?');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_sec_desks_L1?');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_sec_desks_L2345');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_sec_desks_L2345');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_truckmod');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_coke01');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_coke02');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_meth01');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_meth02');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_meth03');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_meth04');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed01');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed02');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed03');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed04');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed05');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed06');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed07');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed08');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed09');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed10');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed11');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed12');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed13');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed14');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed15');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Weed16');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged01');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged02');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged03');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged04');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged05');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged06');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged07');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged08');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged09');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged10');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged11');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Forged12');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Cash01?');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Cash02');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Cash03');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Cash04');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Cash05');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Cash06');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Cash07');
mp.game.interior.enableInteriorProp(271873, 'Int02_ba_Cash08');
mp.game.interior.refreshInterior(271873);

//CASINO
//1100.000, 220.000, -50.000
mp.game.streaming.requestIpl('vw_casino_main?');
let casinoIntID = mp.game.interior.getInteriorAtCoords(1100.000, 220.000, -50.000);
let casinoPropList = [
    'vw_dlc_casino_door',
    'casino_manager_default',
    'hei_dlc_windows_casino',
    'hei_dlc_casino_aircon',
];

for (const propName of casinoPropList) {
    mp.game.interior.enableInteriorProp(casinoIntID, propName);
    //mp.game.invoke('0x8D8338B92AD18ED6', casinoIntID, propName, 1); // _SET_INTERIOR_PROP_COLOR
}

//PENTHOUSE
//976.636, 70.295, 115.164
mp.game.streaming.requestIpl('vw_casino_penthouse');
let phIntID = mp.game.interior.getInteriorAtCoords(976.636, 70.295, 115.164);
let phPropList = [
    'Set_Pent_Tint_Shell',
    'Set_Pent_Pattern_05',
    'Set_Pent_Spa_Bar_Open',
    'Set_Pent_Media_Bar_Open',
    'Set_Pent_Dealer',
    'Set_Pent_Arcade_Retro',
    'Set_Pent_Bar_Clutter',
    'Set_Pent_Clutter_01',
    'set_pent_bar_light_01',
    'set_pent_bar_party_0',
];

for (const propName of phPropList) {
    mp.game.interior.enableInteriorProp(phIntID, propName);
    //mp.game.invoke('0x8D8338B92AD18ED6', phIntID, propName, 4); // _SET_INTERIOR_PROP_COLOR
}
mp.game.interior.refreshInterior(phIntID);

//Casino car park
//1380.000, 200.000, -50.000
mp.game.streaming.requestIpl('vw_casino_carpark');

//Casino Garage
mp.game.streaming.requestIpl('vw_casino_garage');

//IPL LISTS WIKI
mp.game.streaming.requestIpl('apa_v_mp_h_01_a');
mp.game.streaming.requestIpl('apa_v_mp_h_02_c');
mp.game.streaming.requestIpl('apa_v_mp_h_05_b');
mp.game.streaming.requestIpl('ex_dt1_02_office_02a');

//CEO GARAGE ARCADIUS
mp.game.streaming.requestIpl('imp_dt1_11_cargarage_a');
let ceo1IntID = mp.game.interior.getInteriorAtCoords(-84.2193, -823.0851, 221.0000);
let ceo1PropList = [
    'garage_decor_03',
    'lighting_option04',
    'numbering_style05_n1',
    'numbering_style05_n2',
    'numbering_style05_n3',
];

for (const propName of ceo1PropList) {
    mp.game.interior.enableInteriorProp(ceo1IntID, propName);
    //mp.game.invoke('0x8D8338B92AD18ED6', ceo1IntID, propName, 3); // _SET_INTERIOR_PROP_COLOR
}
mp.game.interior.refreshInterior(ceo1IntID);

//CEO GARAGE MAZE
mp.game.streaming.requestIpl('imp_dt1_02_cargarage_b');
let ceo2IntID = mp.game.interior.getInteriorAtCoords(-117.4989, -568.1132, 135.0000);
let ceo2PropList = [
    'garage_decor_02',
    'lighting_option03',
    'numbering_style03_n1',
    'numbering_style03_n2',
    'numbering_style03_n3',
];


for (const propName of ceo2PropList) {
    mp.game.interior.enableInteriorProp(ceo2IntID, propName);
    //mp.game.invoke('0x8D8338B92AD18ED6', ceo2IntID, propName, 2); // _SET_INTERIOR_PROP_COLOR
}
mp.game.interior.refreshInterior(ceo2IntID);

//CEO GARAGE LOM
mp.game.streaming.requestIpl('imp_sm_13_cargarage_c');
let ceo3IntID = mp.game.interior.getInteriorAtCoords(-1563.5570, -574.4314, 85.5000);
let ceo3PropList = [
    'garage_decor_01',
    'lighting_option01',
    'numbering_style01_n1',
    'numbering_style01_n2',
    'numbering_style01_n3',
];

for (const propName of ceo3PropList) {
    mp.game.interior.enableInteriorProp(ceo3IntID, propName);
    //mp.game.invoke('0x8D8338B92AD18ED6', ceo3IntID, propName, 2); // _SET_INTERIOR_PROP_COLOR
}
mp.game.interior.refreshInterior(ceo2IntID);

//CEO GARAGE MAZE WEST
mp.game.streaming.requestIpl('imp_sm_15_cargarage_a');
let ceo4IntID = mp.game.interior.getInteriorAtCoords(-1388.8400, -478.7402, 56.1000);
let ceo4PropList = [
    'garage_decor_01',
    'lighting_option01',
    'numbering_style01_n1',
    'numbering_style01_n2',
    'numbering_style01_n3',
];

for (const propName of ceo4PropList) {
    mp.game.interior.enableInteriorProp(ceo4IntID, propName);
    //mp.game.invoke('0x8D8338B92AD18ED6', ceo4IntID, propName, 2); // _SET_INTERIOR_PROP_COLOR
}
mp.game.interior.refreshInterior(ceo4IntID);

mp.game.streaming.requestIpl('imp_dt1_11_modgarage');
mp.game.streaming.requestIpl('ex_sm_13_office_03b');
mp.game.streaming.requestIpl('imp_dt1_02_modgarage');
mp.game.streaming.requestIpl('ex_sm_13_office_03c');
mp.game.streaming.requestIpl('imp_sm_15_modgarage');
mp.game.streaming.requestIpl('ex_sm_15_office_02a');
mp.game.streaming.requestIpl('ex_exec_warehouse_placement_interior_1_int_warehouse_s_dlc_milo');
mp.game.streaming.requestIpl('ex_exec_warehouse_placement_interior_0_int_warehouse_m_dlc_milo');
mp.game.streaming.requestIpl('ex_exec_warehouse_placement_interior_2_int_warehouse_l_dlc_milo');
mp.game.streaming.requestIpl('sunkcargoship');
mp.game.streaming.requestIpl('redCarpet');
mp.game.streaming.requestIpl('DES_stilthouse_rebuild');
mp.game.streaming.requestIpl('FINBANK');
mp.game.streaming.requestIpl('TrevorsTrailerTidy');

//YACHT
// def -2027.946, -1036.695, 6.707587
// ???? ????? 1373.828, 6737.393, 6.707596
mp.game.streaming.requestIpl('hei_yacht_heist');
mp.game.streaming.requestIpl('hei_yacht_heist_enginrm');
mp.game.streaming.requestIpl('hei_yacht_heist_Lounge');
mp.game.streaming.requestIpl('hei_yacht_heist_Bridge');
mp.game.streaming.requestIpl('hei_yacht_heist_Bar');
mp.game.streaming.requestIpl('hei_yacht_heist_Bedrm');
mp.game.streaming.requestIpl('hei_yacht_heist_DistantLights');
mp.game.streaming.requestIpl('hei_yacht_heist_LODLights');
mp.game.streaming.requestIpl('gr_case10_bunkerclosed');

mp.game.streaming.removeIpl('rc12b_fixed');
mp.game.streaming.removeIpl('rc12b_destroyed');
mp.game.streaming.removeIpl('rc12b_default');
mp.game.streaming.removeIpl('rc12b_hospitalinterior_lod');
mp.game.streaming.removeIpl('rc12b_hospitalinterior');


 