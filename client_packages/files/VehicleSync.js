

mp.events.add("VehStream_SetEngineStatus", (veh, status) => {
    if (veh && mp.vehicles.exists(veh)) {
        if (veh.isSeatFree(-1)) //Turns engine on instantly if no driver, otherwise it will not turn on
        {
            veh.setEngineOn(status, true, false);
            veh.setUndriveable(true);
        }
        else {
            veh.setEngineOn(status, false, true);
            veh.setUndriveable(!status);
        }
    }
});

mp.events.add("VehStream_SetLockStatus", (veh, status) => {
    if (veh && mp.vehicles.exists(veh)) {
        if (status) {
            veh.setDoorsLocked(2);
            mp.game.audio.playSoundFromEntity(1, "Remote_Control_Close", veh.handle, "PI_Menu_Sounds", true, 0);

        }
        else
        {
            mp.game.audio.playSoundFromEntity(1, "Remote_Control_Open", veh.handle, "PI_Menu_Sounds", true, 0);
            veh.setDoorsLocked(1);
        }
       
    }
});



mp.events.add("VehStream_PlayerExitVehicleAttempt", (entity) => {
    if (entity && mp.vehicles.exists(entity)) {
        if (typeof entity.getVariable("VehicleSyncData") !== 'undefined') {
            var toggle = entity.getVariable("VehicleSyncData");
            entity.setEngineOn(toggle.Engine, true, false);
            entity.setUndriveable(!toggle.Engine);
        }

        var level = entity.getDirtLevel();
        mp.events.callRemote("VehStream_SetDirtLevel", entity, level);
    }
});

mp.events.add("VehStream_PlayerExitVehicle", (entity) => {
    setTimeout(() => {
        if (mp.vehicles.exists(entity)) {
            var Status = [];
            let y = 0;
            for (y = 0; y < 8; y++) {
                if (entity == null) { return; }
                if (entity.isDoorDamaged(y)) {
                    Status.push(2);
                }
                else if (entity.getDoorAngleRatio(y) > 0.15) {
                    Status.push(1);
                }
                else {
                    Status.push(0);
                }
            }
            mp.events.callRemote("VehStream_SetDoorData", entity, Status[0], Status[1], Status[2], Status[3], Status[4], Status[5], Status[6], Status[7]);

            Status = [];
            if (entity.isWindowIntact(0)) {
                if (entity.getBoneIndexByName("window_rf") === -1) {
                    Status.push(1);
                }
                else {
                    Status.push(0);
                }
            }
            else {
                Status.push(2);
            }
            if (entity.isWindowIntact(1)) {
                if (entity.getBoneIndexByName("window_lf") === -1) {
                    Status.push(1);
                }
                else {
                    Status.push(0);
                }
            }
            else {
                Status.push(2);
            }
            if (entity.isWindowIntact(2)) {
                if (entity.getBoneIndexByName("window_rr") === -1) {
                    Status.push(1);
                }
                else {
                    Status.push(0);
                }
            }
            else {
                Status.push(2);
            }
            if (entity.isWindowIntact(3)) {
                if (entity.getBoneIndexByName("window_lr") === -1) {
                    Status.push(1);
                }
                else {
                    Status.push(0);
                }
            }
            else {
                Status.push(2);
            }
            mp.events.callRemote("VehStream_SetWindowData", entity, Status[0], Status[1], Status[2], Status[3]);

            Status = [];
            if (!entity.isTyreBurst(0, false)) {
                Status.push(0);
            }
            else if (entity.isTyreBurst(0, false)) {
                Status.push(1);
            }
            else {
                Status.push(2);
            }

            if (!entity.isTyreBurst(1, false)) {
                Status.push(0);
            }
            else if (entity.isTyreBurst(1, false)) {
                Status.push(1);
            }
            else {
                Status.push(2);
            }

            if (!entity.isTyreBurst(2, false)) {
                Status.push(0);
            }
            else if (entity.isTyreBurst(2, false)) {
                Status.push(1);
            }
            else {
                Status.push(2);
            }

            if (!entity.isTyreBurst(3, false)) {
                Status.push(0);
            }
            else if (entity.isTyreBurst(3, false)) {
                Status.push(1);
            }
            else {
                Status.push(2);
            }

            if (!entity.isTyreBurst(4, false)) {
                Status.push(0);
            }
            else if (entity.isTyreBurst(4, false)) {
                Status.push(1);
            }
            else {
                Status.push(2);
            }

            if (!entity.isTyreBurst(5, false)) {
                Status.push(0);
            }
            else if (entity.isTyreBurst(5, false)) {
                Status.push(1);
            }
            else {
                Status.push(2);
            }

            if (!entity.isTyreBurst(6, false)) {
                Status.push(0);
            }
            else if (entity.isTyreBurst(6, false)) {
                Status.push(1);
            }
            else {
                Status.push(2);
            }

            if (!entity.isTyreBurst(7, false)) {
                Status.push(0);
            }
            else if (entity.isTyreBurst(7, false)) {
                Status.push(1);
            }
            else {
                Status.push(2);
            }

            if (!entity.isTyreBurst(45, false)) {
                Status.push(0);
            }
            else if (entity.isTyreBurst(45, false)) {
                Status.push(1);
            }
            else {
                Status.push(2);
            }

            if (!entity.isTyreBurst(47, false)) {
                Status.push(0);
            }
            else if (entity.isTyreBurst(47, false)) {
                Status.push(1);
            }
            else {
                Status.push(2);
            }

            mp.events.callRemote("VehStream_SetWheelData", entity, Status[0], Status[1], Status[2], Status[3], Status[4], Status[5], Status[6], Status[7], Status[8], Status[9]);
        }
    }, 2500);
});

mp.events.add("VehStream_PlayerEnterVehicleAttempt", (entity, seat) => {
    if (!entity) { //fix
        return;
    }
    if (typeof entity.getVariable("VehicleSyncData") !== 'undefined') {
        var toggle = entity.getVariable("VehicleSyncData");
        entity.setEngineOn(toggle.Engine, false, true);
        entity.setUndriveable(!toggle.Engine);
    }
    if (entity.getVariable("VehFreezed") == true) {
        mp.events.call('ForeachFreezeVeh',entity,true);
    }
    setTimeout(() => {
        if (mp.vehicles.exists(entity)) {

            var Status = [];
            let y = 0;
            for (y = 0; y < 8; y++) {
                if (entity.isDoorDamaged(y)) {
                    Status.push(2);
                }
                else if (entity.getDoorAngleRatio(y) > 0.15) {
                    Status.push(1);
                }
                else {
                    Status.push(0);
                }
            }
            //mp.events.callRemote("VehStream_SetDoorData", entity, Status[0], Status[1], Status[2], Status[3], Status[4], Status[5], Status[6], Status[7]);

            Status = [];
            if (entity.isWindowIntact(0)) {
                if (entity.getBoneIndexByName("window_rf") === -1) {
                    Status.push(1);
                }
                else {
                    Status.push(0);
                }
            }
            else {
                Status.push(2);
            }
            if (entity.isWindowIntact(1)) {
                if (entity.getBoneIndexByName("window_lf") === -1) {
                    Status.push(1);
                }
                else {
                    Status.push(0);
                }
            }
            else {
                Status.push(2);
            }
            if (entity.isWindowIntact(2)) {
                if (entity.getBoneIndexByName("window_rr") === -1) {
                    Status.push(1);
                }
                else {
                    Status.push(0);
                }
            }
            else {
                Status.push(2);
            }
            if (entity.isWindowIntact(3)) {
                if (entity.getBoneIndexByName("window_lr") === -1) {
                    Status.push(1);
                }
                else {
                    Status.push(0);
                }
            }
            else {
                Status.push(2);
            }
            mp.events.callRemote("VehStream_SetWindowData", entity, Status[0], Status[1], Status[2], Status[3]);
        }
    }, 3000);
});

mp.events.add("VehStream_SetVehicleDirtLevel", (entity, dirt) => {
    if (entity && mp.vehicles.exists(entity)) {
        entity.setDirtLevel(dirt);
    }
});

mp.events.add("VehStream_SetVehicleDoorStatus_Single", (veh, door, state) => {
    if (veh && mp.vehicles.exists(veh)) {
        if (state === 0) {
            veh.setDoorShut(door, false);
        }
        else if (state === 1) {
            veh.setDoorOpen(door, false, false);
        }
        else {
            veh.setDoorBroken(door, true);
        }
    }
});

mp.events.add("VehStream_SetVehicleDoorStatus", (...args) => {
    if (args[0] && mp.vehicles.exists(args[0])) {
        let y = 0;
        for (y = 1; y < args.length; y++) {
            if (args[y] === 0) {
                args[0].setDoorShut(y - 1, false);
            }
            else if (args[y] === 1) {
                args[0].setDoorOpen(y - 1, false, false);
            }
            else {
                args[0].setDoorBroken(y - 1, true);
            }
        }
    }
});

mp.events.add("VehStream_SetVehicleWindowStatus_Single", (veh, windw, state) => {
    if (veh && mp.vehicles.exists(veh)) {
        if (state === 1) {
            veh.rollDownWindow(windw);
        }
        else if (state === 0) {
            veh.fixWindow(windw);
            veh.rollUpWindow(windw);
        }
        else {
            veh.smashWindow(windw);
        }
    }
});

mp.events.add("VehStream_SetVehicleWindowStatus", (...args) => {
    if (args[0] && mp.vehicles.exists(args[0])) {
        let y = 0;
        for (y = 1; y < 4; y++) {
            if (args[y] === 1) {
                args[0].rollDownWindow(y - 1);
            }
            else if (args[y] === 0) {
                args[0].fixWindow(y - 1);
                args[0].rollUpWindow(y - 1);
            }
            else {
                args[0].smashWindow(y - 1);
            }
        }
    }
});

mp.events.add("VehStream_SetVehicleWheelStatus_Single", (veh, wheel, state) => {
    if (veh && mp.vehicles.exists(veh)) {
        if (wheel === 9) {
            if (state === 1) {
                veh.setTyreBurst(45, false, 1000);
            }
            else if (state === 0) {
                veh.setTyreFixed(45);
            }
            else {
                veh.setTyreBurst(45, true, 1000);
            }
        }
        else if (wheel === 10) {
            if (state === 1) {
                veh.setTyreBurst(47, false, 1000);
            }
            else if (state === 0) {
                veh.setTyreFixed(47);
            }
            else {
                veh.setTyreBurst(47, true, 1000);
            }
        }
        else {
            if (state === 1) {
                veh.setTyreBurst(wheel, false, 1000);
            }
            else if (state === 0) {
                veh.setTyreFixed(wheel);
            }
            else {
                veh.setTyreBurst(wheel, true, 1000);
            }
        }
    }
});

mp.events.add("VehStream_SetVehicleWheelStatus", (...args) => {
    if (args[0] && mp.vehicles.exists(args[0])) {
        let y = 0;
        for (y = 1; y < args.length; y++) {
            if (y === 9) {
                if (args[y] === 1) {
                    args[0].setTyreBurst(45, false, 1000);
                }
                else if (args[y] === 0) {
                    args[0].setTyreFixed(45);
                }
                else {
                    args[0].setTyreBurst(45, true, 1000);
                }
            }
            else if (y === 10) {
                if (args[y] === 1) {
                    args[0].setTyreBurst(47, false, 1000);
                }
                else if (args[y] === 0) {
                    args[0].setTyreFixed(47);
                }
                else {
                    args[0].setTyreBurst(47, true, 1000);
                }
            }
            else {
                if (args[y] === 1) {
                    args[0].setTyreBurst(y - 1, false, 1000);
                }
                else if (args[y] === 0) {
                    args[0].setTyreFixed(y - 1);
                }
                else {
                    args[0].setTyreBurst(y - 1, true, 1000);
                }
            }
        }
    }
});

//Sync data on stream in
mp.events.add("entityStreamIn", (entity) => {
    if (entity.type === "vehicle") {
        let typeor = typeof entity.getVariable('VehicleSyncData');
        let actualData = entity.getVariable('VehicleSyncData');

        //Needed to stop vehicles from freaking out
        mp.game.streaming.requestCollisionAtCoord(entity.position.x, entity.position.y, entity.position.z);
        mp.game.invoke('0xC9156DC11411A9EA', entity.position.x, entity.position.y, entity.position.z);
        entity.setLoadCollisionFlag(true);
        entity.trackVisibility();

        //Set doors unbreakable for a moment
        let x = 0;
        for (x = 0; x < 8; x++) {
            if (mp.vehicles.exists(entity)) {
                entity.setDoorBreakable(x, false);
            }
            
        }

        //Do it anyway
        entity.setUndriveable(true);

        if (typeor !== 'undefined') {
            if (mp.vehicles.exists(entity)) {
                entity.setEngineOn(actualData.Engine, true, false);
                entity.setUndriveable(true);

                if (actualData.Locked)
                    entity.setDoorsLocked(2);
                else
                    entity.setDoorsLocked(1);

                entity.setDirtLevel(actualData.Dirt);

                for (x = 0; x < 8; x++) {
                    if (actualData.Door[x] === 1)
                        entity.setDoorOpen(x, false, false);
                    else if (actualData.Door[x] === 0)
                        entity.setDoorShut(x, true);
                    else
                        entity.setDoorBroken(x, true);
                }

                for (x = 0; x < 4; x++) {
                    if (actualData.Window[x] === 0) {
                        entity.fixWindow(x);
                    }
                    else if (actualData.Window[x] === 1) {
                        entity.rollDownWindow(x);
                    }
                    else {
                        entity.smashWindow(x);
                    }
                }

                for (x = 0; x < 8; x++) {
                    if (actualData.Wheel[x] === 0) {
                        entity.setTyreFixed(x);
                    }
                    else if (actualData.Wheel[x] === 1) {
                        entity.setTyreBurst(x, false, 0);
                    }
                    else {
                        entity.setTyreBurst(x, true, 1000);
                    }
                }

                //For trailer mid wheels
                if (actualData.Wheel[8] === 0) {
                    entity.setTyreFixed(45);
                }
                else if (actualData.Wheel[8] === 1) {
                    entity.setTyreBurst(45, false, 0);
                }
                else {
                    entity.setTyreBurst(45, true, 1000);
                }

                if (actualData.Wheel[9] === 0) {
                    entity.setTyreFixed(47);
                }
                else if (actualData.Wheel[9] === 1) {
                    entity.setTyreBurst(47, false, 0);
                }
                else {
                    entity.setTyreBurst(47, true, 1000);
                }
            }
        }

        //Make doors breakable again
        setTimeout(() => {
            for (x = 0; x < 8; x++) {
                if (mp.vehicles.exists(entity)) {
                    entity.setDoorBreakable(x, true);
                }
            }
        }, 1500);
    }
});


var rtimer = null;
var nowplaying;

function vehradio(entity) {
    if (entity && mp.vehicles.exists(entity)) {
        if (localplayer.vehicle == entity) {
            let vehrad = entity.getVariable('vehradio');
            nowplaying = mp.game.invoke('0xE8AF77C4C06ADC93');
            if (entity.getPedInSeat(-1) == localplayer.handle) {
                if (vehrad != nowplaying) mp.events.callRemote('VehStream_RadioChange', entity, nowplaying);
            } else {
                if (vehrad == 255) mp.game.audio.setRadioToStationName("OFF");
                else {
                    if (vehrad != nowplaying) {
                        mp.game.invoke('0xF7F26C6E9CC9EBB8', true);
                        mp.game.invoke('0xA619B168B8A8570F', vehrad);
                    }

                }
            }
        }
    } else {
        if (rtimer != null) {
            clearInterval(rtimer);
            rtimer = null;
        }
    }
};

mp.events.add("playerEnterVehicle", (entity, seat) => {
    if (entity != null) {
        if (rtimer != null) clearInterval(rtimer);
        rtimer = setInterval(function () { vehradio(entity); }, 1000);
    }
});

mp.events.add("playerLeaveVehicle", (entity) => {
    if (rtimer != null) {
        clearInterval(rtimer);
        rtimer = null;
    }
});
