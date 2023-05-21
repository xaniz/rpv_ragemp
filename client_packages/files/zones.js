﻿const positions = [
    //{ 'position': { 'x': -200.8397, 'y': -1431.556, 'z': 30.18104 }, 'color': 10 },
]

const zones = [];
mp.events.add('loadCapturezones', function () {
    positions.forEach(element => {
        const blip = mp.game.ui.addBlipForRadius(element.position.x, element.position.y, element.position.z, element.range);
       // mp.game.invoke(getNative("SET_BLIP_SPRITE"), blip, 5);
        mp.game.invoke("0x45FF974EEE1C8734", blip, element.alpha);
        mp.game.invoke(getNative("SET_BLIP_COLOUR"), blip, element.color);
        zones.push(blip);
    });
});

mp.events.add('CreateZone', function (x, y, z, colorid, range, alpha) {
    positions.push({ 'position': { 'x': x, 'y': y, 'z': z }, 'color': colorid, 'range': range, 'alpha': alpha });
});

mp.events.add('setZonePosition', function (id, x, y, z) {
    mp.game.invoke("0xAE2AF67E9D9AF65D", zones[id], x, y, z);
});
mp.events.add('setZoneAlpha', function (id, alpha) {
    mp.game.invoke("0x45FF974EEE1C8734", zones[id], alpha);
});
mp.events.add('setZoneColor', function (id, color) {
    mp.game.invoke(getNative("SET_BLIP_COLOUR"), zones[id], color);
});
mp.events.add('setZoneFlash', function (id, state) {
    mp.game.invoke(getNative("SET_BLIP_FLASH_TIMER"), zones[id], 1000);
    mp.game.invoke(getNative("SET_BLIP_FLASHES"), zones[id], state);
});

mp.events.add('render', () => {
    if (zones.length !== 0) {
        zones.forEach(blip => {
            mp.game.invoke(getNative("SET_BLIP_ROTATION"), blip, 0);
        })
    }
});

mp.events.add('quitcmd', function () {
    zones.forEach(blip => {
        mp.game.invoke("0x45FF974EEE1C8734", blip, 0);
    });
    mp.events.callRemote('kickclient');
});


