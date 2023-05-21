const Client = mp.players.local;

const fov_max = 70.0;
const fov_min = 5.0;
const hiddenComponents = [0, 1, 2, 3, 4, 11, 12, 13, 15, 18, 19];
const gameplay = mp.cameras.new('gameplay');
const Natives = {
    CLEAR_TIMECYCLE_MODIFIER: "0x0F07E7745A236711",
    GET_DISABLED_CONTROL_NORMAL: "0x11E65974A982637C",
    SET_CAM_INHERIT_ROLL_VEHICLE: "0x45F1DE9C34B93AE6"
};
/** Script Keybinds **/
let keyOptions = {
    toggleCamera: 51,       // Keyboard: "E" Key.
    cameraZoomIn: 42,         // Keyboard:
    cameraZoomOut: 43,         // Keyboard:
    cameraVision: 71,       // Mouse: "Right Mouse Button".
    toggleSpotlight: 183,   // Keyboard: "G" Key.
    cameraLock: 22          // Keyboard: Spacebar.
};
 
/** Script Variables **/
let flirOptions = {
    currentHelicopter: null,
    policeCameraEnabled: false,
    policeCameraLock: false,
    policeVisionState: 0,
    policeSpotlightState: 0,
    policeCameraTarget: null,
    nvision: false,
    scaleForm: mp.game.graphics.requestScaleformMovie("HELI_CAM")
};
/** Script Functions **/
function getHelicopterHeight(vehicle) {
    return vehicle.getHeightAboveGround() > 1.5;
}
 
function setHelicopterVision() {
	if(Client.vehicle.getPedInSeat(0) != Client.handle && flirOptions.policeVisionState == 1)flirOptions.policeVisionState = 2;
    switch(flirOptions.policeVisionState) {
        case 0:
            mp.game.graphics.setNightvision(true);
            flirOptions.policeVisionState = 1;
            break;
        case 1:
			
            mp.game.graphics.setNightvision(false);
            mp.game.graphics.setSeethrough(true);
            flirOptions.policeVisionState = 2;
            break;
        default:
		
            mp.game.graphics.setNightvision(false);
            mp.game.graphics.setSeethrough(false);
            flirOptions.policeVisionState = 0;
            break;
    }
    return flirOptions.policeVisionState;
}




function CloseChoperVision() {
    if (flirOptions.policeVisionState == 1 || flirOptions.policeVisionState == 2) {
        mp.game.graphics.setNightvision(false);
        mp.game.graphics.setSeethrough(false);
        flirOptions.policeVisionState = 0;
    }

}
function zoomIn(zoom) {
    if(!Client.vehicle) return false;
    if (Client.vehicle.model !== mp.game.joaat("polmav")) return;

    let fov = flirOptions.currentHelicopter.getFov(flirOptions.currentHelicopter);
    
    if((fov + zoom) < fov_max) flirOptions.currentHelicopter.setFov(fov + zoom);
}

function zoomOut(zoom) {
    if(!Client.vehicle) return false;
    if (Client.vehicle.model !== mp.game.joaat("polmav")) return;

    let fov = flirOptions.currentHelicopter.getFov(flirOptions.currentHelicopter);
    
    if((fov - zoom) > fov_min) flirOptions.currentHelicopter.setFov(fov - zoom);
}
 
function setHudStateForFrame() {
    hiddenComponents.forEach(item => {
        mp.game.ui.hideHudComponentThisFrame(item);
    });
}

mp.keys.bind(76, true, function() { // L
    if (!Client.vehicle || chatopened) return false;
    if (Client.vehicle.model !== mp.game.joaat("polmav")) return;
    if(Client.vehicle.getPedInSeat(0) != Client.handle) return;
    flirOptions.policeCameraLock = !flirOptions.policeCameraLock;

    mp.game.graphics.notify(flirOptions.policeCameraLock ? 'Kamera zakljucana: ~w~.' : 'Kamera otkljucana~w~.');
});

mp.keys.bind(71, true, function() { // G
    if (!Client.vehicle || chatopened) return false;
    if (Client.vehicle.model !== mp.game.joaat("polmav")) return;
    if(Client.vehicle.getPedInSeat(0) != Client.handle) return;
    if(!flirOptions.nvision){
        mp.game.graphics.setNightvision(true);
        mp.game.graphics.setSeethrough(true);
        flirOptions.nvision = true;
        return;
    }else if (flirOptions.nvision){
        mp.game.graphics.setNightvision(false);
        mp.game.graphics.setSeethrough(false);
        flirOptions.nvision = false;
        return;
    }
        

});

mp.keys.bind(69, true, function() { // E
    if(!Client.vehicle || chatopened) return false;
    if (Client.vehicle.model !== mp.game.joaat("polmav")) return;
	if(Client.vehicle.getPedInSeat(0) != Client.handle) return;
	
    flirOptions.policeCameraEnabled = !flirOptions.policeCameraEnabled;
    mp.game.audio.playSoundFrontend(-1, "SELECT", "HUD_FRONTEND_DEFAULT_SOUNDSET", false);

    if(!flirOptions.policeCameraEnabled) {
        mp.game.cam.renderScriptCams(false, false, 1, true, false);
        flirOptions.currentHelicopter.setActive(false);
        flirOptions.currentHelicopter.detach();
		mp.game.ui.displayRadar(true);
		      
		
			mp.events.callRemote('Display_HUD', true);
			mp.events.callRemote('Show_Chat', true);
        mp.game.graphics.setNightvision(false);
        mp.game.graphics.setSeethrough(false);

        mp.game.audio.playSoundFrontend(-1, "SELECT", "HUD_FRONTEND_DEFAULT_SOUNDSET", false);
        mp.game.graphics.setScaleformMovieAsNoLongerNeeded(flirOptions.scaleForm);

        mp.game.invoke(Natives.CLEAR_TIMECYCLE_MODIFIER);
        flirOptions.currentHelicopter = null;
    } else if(flirOptions.currentHelicopter == null) {
            flirOptions.currentHelicopter = mp.cameras.new('default', Client.vehicle.position, new mp.Vector3(0,0,0), 40.0);
			
			mp.game.ui.displayRadar(false);
			
			mp.events.callRemote('Display_HUD', false);
			mp.events.callRemote('Show_Chat', false);
            
			flirOptions.currentHelicopter.attachTo(Client.vehicle.handle, 0.0, 2.8, -1., true);
            flirOptions.currentHelicopter.setActive(true);

            mp.game.cam.renderScriptCams(true, false, 1, true, false);
    }

    mp.game.graphics.notify(flirOptions.policeCameraEnabled ? 'Kamera: ~g~Ukljucena~w~.' : 'Kamera: ~r~Iskljucena~w~.');
});
 
mp.events.add("render", () => {

    if (flirOptions.policeVisionState == 1 || flirOptions.policeVisionState == 2  && !Client.vehicle) {
        CloseChoperVision();
    }
    if(!Client.vehicle) return false;
    if (Client.vehicle.model !== mp.game.joaat("polmav")) return;

    const controls = mp.game.controls;
 
    
        if (flirOptions.policeCameraEnabled) {
            const adjustZoomValue = (1.0 / 90.00 - 7.5);

            if(!mp.game.graphics.hasScaleformMovieLoaded(flirOptions.scaleForm)) {
                flirOptions.scaleForm = mp.game.graphics.requestScaleformMovie("HELI_CAM");
            }
			mp.game.controls.disableControlAction(0, 75, true);

            mp.game.graphics.setTimecycleModifier("heliGunCam");
            mp.game.graphics.setTimecycleModifierStrength(0.3);

            // mp.game.invoke(Natives.SET_CAM_INHERIT_ROLL_VEHICLE, flirOptions.currentHelicopter, true);
 
            if(!flirOptions.policeCameraLock) {
                let currentRotation = gameplay.getRot(2);
                flirOptions.currentHelicopter.setRot(currentRotation.x, currentRotation.y, currentRotation.z, 2);
            }
 
            mp.game.graphics.pushScaleformMovieFunction(flirOptions.scaleForm, "SET_CAM_LOGO");
            mp.game.graphics.pushScaleformMovieFunctionParameterInt(1);
            mp.game.graphics.popScaleformMovieFunctionVoid();
 
            /** Todo: Camera: Zoom Function */
            if (controls.isControlJustPressed(0, keyOptions.cameraZoomIn)) {
                zoomIn(3);
            }

            if (controls.isControlJustPressed(0, keyOptions.cameraZoomOut)) {
                zoomOut(3);
            }
 
            /** Todo:Camera: Lock Target **/
            if (controls.isControlJustPressed(0, keyOptions.cameraLock))
            {
                if (flirOptions.policeCameraTarget) {
                    mp.gui.chat.push(`Camera locked enabled.`);
                } else {
                    mp.gui.chat.push(`Camera lock isn't set, lock on to vehicle/player.`);
               }
           }
           
           setHudStateForFrame();
           mp.game.graphics.pushScaleformMovieFunction(flirOptions.scaleForm, "SET_ALT_FOV_HEADING");
           mp.game.graphics.pushScaleformMovieFunctionParameterFloat(Client.vehicle.getCoords(true).z);
           mp.game.graphics.pushScaleformMovieFunctionParameterFloat(adjustZoomValue);
           mp.game.graphics.pushScaleformMovieFunctionParameterFloat(Client.vehicle.getHeading());
           mp.game.graphics.popScaleformMovieFunctionVoid()
           mp.game.graphics.drawScaleformMovieFullscreen(flirOptions.scaleForm, 255, 255, 255, 255, true);
       }
   
});