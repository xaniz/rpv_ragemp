const Misc = require('copsnrobbers/core/misc.js');
const Client = require('copsnrobbers/core/client.js');
const Game = require('copsnrobbers/core/game.js');
const Key = require('copsnrobbers/core/key.js');

let mdc = null, mdc_menu = false, crimes = [];

Key.add('toggleMDC', false, 75);

mp.events.add({
    "initMDC": () => {
        mdc = Game.browser("package://copsnrobbers/menus/mdc/index.html");
    },
    "destroyMDC": () => {
        if(mdc) {
            mdc.destroy();
            mdc_menu = false;
        }
    },
    "openMDC": () => {
        if(Client.isReady(Client.player)) {
            if(Client.player.shared.team.id != 1 || Client.player.shared.team.duty != 1) return false;
            if(Client.isChat) return false;
            if(mdc && !mdc_menu) {
                Client.setCursor(true);
                mdc_menu = true;
                Key.mdc(true);
                mdc.executeLog(`toggleMDC(true);`);
            }
        }
    },
    "closeMDC": () => {
        if(mdc && mdc_menu) {
            Client.setCursor(false);

            mdc_menu = false;        
            Key.mdc(false);

            mdc.executeLog(`toggleMDC(false);`);
        }
    },
    "toggleMDC": () => {
        if(Client.player.debug) Game.debug('MDC -> main.js -> toggleMDC called');

        if(mdc) {
            if(mdc_menu) {
                Client.call('closeMDC');
            } else Client.call('openMDC');
        }
    },
    "registerCrime": (crimeArr, sound) =>
  	{
        if(mdc) {
            let crime = JSON.parse(crimeArr);
            
            let getStreet = Game.getStreetHash(crime.position.x, crime.position.y, crime.position.z, 0, 0);
            let streetName = Game.getStreetName(getStreet.streetName);
            let crossingRoad  = Game.getStreetName(getStreet.crossingRoad);
            
            let zoneName = Game.getZoneFullName(crime.position.x, crime.position.y, crime.position.z);
            let distance = Game.travelDistance(Client.player.position, crime.position);
            let fullStreet = '';
            let realZoneName = '';
            
            crimes.push(crime);
            
            if(crossingRoad != 0) {
              fullStreet = streetName + ', ' + crossingRoad;
            } else {
              fullStreet = streetName;
            }

            setTimeout(function() {
                Client.call("playClientSound", sound, 0.7);
            }, 200);
            Client.pushNotification("Dispatch", "Emergency call", "CHAR_CALL911", crime.title + '\nHold [~b~K~w~] to toggle the MDC', true, 1);
            mdc.executeLog(`reportCrime('${crime.reportID}', '${crime.title}', '${zoneName}', '${fullStreet}', '${distance}');`);
        }
  	},
      "respondToCrime": (id) =>
  	{
        crimes.forEach((crime) => {
            if(crime.reportID == id) {
                Game.waypoint(crime.position.x, crime.position.y);
                Client.remote('respondToCrime', id);
            }
        });
  	},"removeCrime": (id) =>
  	{
        Client.remote('removeCrime', id);
  	},
    "respondingCrime": (id) =>     
  	{
        if(mdc) {
            mdc.executeLog(`responding('${id}');`);
        }        
    }
});