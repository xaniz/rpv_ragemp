var lifeinvader = null;

mp.events.add('Client:CreateLifeinvader', () => {
    try {

        if (lifeinvader == null) {
            lifeinvader = mp.browsers.new("package://cef/Lifeinvader/index.html");
            lifeinvader.active = true;
            mp.gui.cursor.show(true, true);
        }
    } catch (error) {
        mp.game.graphics.notify(error);
    }
});

mp.events.add('Client:DestroyLifeinvader', () => {
    try {
        if (lifeinvader != null) {
            lifeinvader.active = false;
            lifeinvader.destroy();
            lifeinvader = null;
            setTimeout(() => {
                mp.gui.cursor.show(false, false);
            }, 250);
        }
    } catch (error) {
        mp.game.graphics.notify(error);
    }
});

mp.events.add("Client:Lifeinvader:SubmitPost", (content, phonenumber, price, currentType) => {
    if (lifeinvader != null) {
        mp.events.call('Client:DestroyLifeinvader');

        if (content.length <= 0 || phonenumber.toString().length <= 0) {
            mp.events.call('Client:CreateNotification', "Fehlgeschlagen", "Bitte fülle alle Felder aus!", 5000, "fa-times-circle", 255, 0, 0)
            return;
        }

        if (content.length <= 3) {
            mp.events.call('Client:CreateNotification', "Fehlgeschlagen", "Dein Werbetext muss mindestens 4 Zeichen lang sein", 5000, "fa-times-circle", 255, 0, 0)
            return;
        }

        mp.events.callRemote("Server:SendLifeinvaderMessage", content, phonenumber, price, currentType);
    }
});