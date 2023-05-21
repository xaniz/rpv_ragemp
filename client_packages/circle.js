global.circleEntity = null;
global.circleOpen = false;
var circleTitle = "";


function OpenCircle(title, data) {
	
    if (circleOpen) return;
	mp.gui.cursor.visible = true;
    uiPlayer_Browsers.execute(`circle.show("${title}",${data})`);
    circleTitle = title;
    circleOpen = true;
}
function CloseCircle(hide) {
    if(hide) uiPlayer_Browsers.execute("circle.hide()");
    circleOpen = false;
	mp.gui.cursor.visible = false;
}

// // //
mp.events.add('circleCallback', (index) => {

    if (index == -1) {
        CloseCircle(false);
    } else {
        CloseCircle(false);
		

		switch (circleTitle) {
            case "vehicle":

                switch (index) {
                    case 0:
						circleOpen = false;
                        OpenCircle("vehgeneral", 0);
					return;
					case 1:
					
						circleOpen = false;
                        OpenCircle("tools", 0);
					return;
					case 2:
					if (pFraction == 1 || pFraction == 2)
					{
						circleOpen = false;
                        OpenCircle("faction", pFraction);
					}

                        return;
                }
                return;
			case"vehgeneral":
			{
					if (entity == null) return;
                    mp.events.callRemote('vehicleSelected', entity, index);

				return;
			}
			case "tools":
			mp.events.callRemote('toolselected', entity, Tools[index]);
			return;
            case "player":
                if (entity == null) return;
                switch (index) {
                    case 0:
                        circleOpen = false;
						OpenCircle("showpasp", 0);
                        return;
                    case 1:
                        if (pFraction === 0) return;
                        OpenCircle("pfaction", pFraction);
                        return;
                    case 2:
					mp.events.callRemote('pSelected', entity, "shake");
					return;
					case 3:
					mp.events.callRemote('pSelected', entity, "showpas");
					return;
					case 4:
					mp.events.callRemote('pSelected', entity, "give money");
					return;
                }
				return;

			case "showpasp":
			switch	(index)
			{
				           
				case 0:
                mp.events.callRemote('pSelected', entity, "Search");
                return;
				case 1:
                mp.events.callRemote('pSelected', entity, "Rob");
                return;
				
			}
			return;
            case "faction":
				switch(pFraction)
				{
					case 1:
						switch (index) {
							case 0:
									if (entity == null) return;
									circleEntity = entity;
									if (fractionActions[pFraction] == undefined) return;
									mp.events.callRemote('fselected', entity,"Impound_Car");
									return;
							case 1:
									if (pFraction === 0) return;
									circleOpen = false;
									OpenCircle("fine", 0);
									return;
							case 2:
									if (pFraction === 0) return;
									circleOpen = false;
									OpenCircle("takeout", 0);
									return;
							case 3:
									//mp.events.callRemote('furnSelected', entity._furnid, "Убрать");
								return;
						}
						return;
				}
			
                return;
			case "pfaction":
				switch(pFraction)
				{
					case 1:
					{
					
						switch (index) {
							case 0:
									if (pFraction === 0) return;
									circleEntity = entity;
									mp.events.callRemote('pSelected', entity,"cufuncuff");
									return;
							case 1:
									if (pFraction === 0) return;
									mp.events.callRemote('pSelected',entity, "dragdrop");
									return;
							case 2:
									if (pFraction === 0) return;
									circleOpen = false;
									OpenCircle("fine", 0);
									return;
							case 3:
									if (pFraction === 0) return;
									circleOpen = false;
									OpenCircle("takeout", 0);
								return;
							case 4:
									if (pFraction === 0) return;
									circleOpen = false;
									//OpenCircle("takeout", 0);
									mp.events.callRemote('pSelected', entity, "AC");
								return;
							case 5:
									if (pFraction === 0) return;
									mp.events.callRemote('pSelected',entity, "mrevive");
									return;
								
								return;
						}
						return;
				    }
					case 2:
					{
						switch (index) {						
							case 0:
									if (pFraction === 0) return;
									mp.events.callRemote('pSelected',entity, "mrevive");
									return;
								return;
							case 1:
									if (pFraction === 0) return;
									mp.events.callRemote('pSelected',entity, "treatment");
									return;
								return;
							case 2:
									if (pFraction === 0) return;
									mp.events.callRemote('pSelected',entity, "dragdrop");
									return;
								return;
							case 3:
									if (pFraction === 0) return;
									circleOpen = false;
									OpenCircle("takeout", 0);
								return;
								
						}
						return;
					}
				}
			
                return;
			case "fine":
			if (entity == null) return;
						circleEntity = entity;
						if (pFraction == 1 || pFraction == 2)
						{
							mp.events.callRemote('fineselected', entity, Fine[index]);
						}
						
            return;
			case "takeout":
			if (entity == null) return;
						circleEntity = entity;
						if (pFraction == 1 || pFraction == 2)
						{
							mp.events.callRemote('takeoutselected', entity, takeout[index]);
						}
						
                return;
            case "animation":
                if (localplayer.isFalling()) return;
                if (index == 7) {
                    mp.events.callRemote('aSelected', -1, -1);
                    return;
                }
                switch (index) {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        aCategory = index;
                        OpenCircle("Анимации 1", index);
                        return;
                }
                return;
            case "Анимации 1":
                if (localplayer.isFalling()) return;
                if (index == 7)
                    OpenCircle("Анимации 2", aCategory);
                else
                    mp.events.callRemote('aSelected', aCategory, index);
                return;
            case "Анимации 2":
                if (localplayer.isFalling()) return;
                mp.events.callRemote('aSelected', aCategory, index + 7);
                return;
        }
    }
});

var aCategory = -1;

var Fine = ["1000", "2000", "3500", "5000","7500","10000"];
var Tools = ["carrep", "refuel"];
var takeout = [1, 2];

var pFraction = 0;
var fractionActions = [];
fractionActions[1] = ["Impound Car","fine","takeout"];
fractionActions[2] = ["takeout"];
fractionActions[3] = ["Ограбить"];
fractionActions[4] = ["Ограбить"];
fractionActions[5] = ["Ограбить"];
fractionActions[6] = ["Вести за собой"];
fractionActions[7] = ["Вести за собой", "Обыскать", "Изъять оружие", "Изъять нелегал", "Сорвать маску", "Выписать штраф"];
fractionActions[8] = ["Продать аптечку", "Предложить лечение"];
fractionActions[9] = ["Вести за собой", "Обыскать", "Изъять оружие", "Изъять нелегал", "Сорвать маску"];
fractionActions[10] = ["Вести за собой", "Мешок", "Ограбить"];
fractionActions[11] = ["Вести за собой", "Мешок", "Ограбить"];
fractionActions[12] = ["Вести за собой", "Мешок", "Ограбить"];
fractionActions[13] = ["Вести за собой", "Мешок", "Ограбить"];
fractionActions[14] = ["Вести за собой"];

var pfractionActions = [];
pfractionActions[1] = ["Handcuff/Uncuff", "Drop/Drop","Fine","Put in Vehicle"];
pfractionActions[2] = ["Ограбить"];
pfractionActions[3] = ["Ограбить"];
pfractionActions[4] = ["Ограбить"];
pfractionActions[5] = ["Ограбить"];
pfractionActions[6] = ["Вести за собой"];
pfractionActions[7] = ["Вести за собой", "Обыскать", "Изъять оружие", "Изъять нелегал", "Сорвать маску", "Выписать штраф"];
pfractionActions[8] = ["Продать аптечку", "Предложить лечение"];
pfractionActions[9] = ["Вести за собой", "Обыскать", "Изъять оружие", "Изъять нелегал", "Сорвать маску"];
pfractionActions[10] = ["Вести за собой", "Мешок", "Ограбить"];
pfractionActions[11] = ["Вести за собой", "Мешок", "Ограбить"];
pfractionActions[12] = ["Вести за собой", "Мешок", "Ограбить"];
pfractionActions[13] = ["Вести за собой", "Мешок", "Ограбить"];
pfractionActions[14] = ["Вести за собой"];
mp.events.add('factionchange', (fraction) => {
    pFraction = fraction;
});