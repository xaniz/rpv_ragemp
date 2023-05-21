require('./files/main.js');
require('./files/natives.js');
require('./files/events.js');
require('./files/zones.js');
require('./files/xmr/xmr.js');
require('./files/new_voip.js');
require('./files/heli.js');
require('./files/VehicleSync.js');
require('./files/heli2.js');


const localPlayer = mp.players.local;

const currentWeapon = () => mp.game.invoke(getNative("GET_SELECTED_PED_WEAPON"), localPlayer.handle);

mp.events.add('playerWeaponShot', (targetPosition, targetEntity) => {
    var current = currentWeapon();
    var ammo = mp.game.invoke(getNative("GET_AMMO_IN_PED_WEAPON"), localPlayer.handle, current);
    //mp.gui.execute(`HUD.ammo=${ammo};`);

	
	mp.events.callRemote('playerTakeoffWeapon', current, ammo);
	
	
    /*if (ammo <= 0) {
        localPlayer.taskSwapWeapon(false);
       // mp.gui.execute(`HUD.ammo=0;`);
		mp.events.callRemote('playerTakeoffWeapon', current, 0);
		
    }*/
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
/*mp.events.add('syncLight2', (vehicle, sound) => {
    vehicle.setSirenSound(sound)
    chat.push('Syncid');
})*/
