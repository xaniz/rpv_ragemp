
var moving_speeds = [0.05, 0.1, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5, 6.0];
var moving_speed_idx = 0;

var editing_types = ["Position X", "Position Y", "Position Z", "Rotation X", "Rotation Y", "Rotation Z"];
var editing_type_idx = 0;

global.editing = false;
var object = null;

var toggle_rotation = false;

var modelo = -1;
mp.events.add('startBuy', function (model) {
	modelo = mp.game.joaat(model);
    object = mp.objects.new(mp.game.joaat(model), localplayer.getCoords(true),
        {
            rotation: new mp.Vector3(0, 0, 0),
            alpha: 255,
            dimension: localplayer.dimension
        });
    editing = true;
	toggle_rotation = false;
	moving_speed_idx = 0;
	
	mp.gui.cursor.visible = false;
	cursor_status = false;
	//mp.gui.chat.push('O nome '+mp.game.joaat(model)+' é! '+modelo+'');
});

mp.events.add('startEditing', function (model, position, rotation) {
	modelo = mp.game.joaat(model);
    object = mp.objects.new(mp.game.joaat(model), position,
        {
            rotation: rotation,
            alpha: 255,
            dimension: localplayer.dimension
        });
    editing = true;
	toggle_rotation = false;
	moving_speed_idx = 0;
	mp.gui.chat.show(true);
	mp.gui.cursor.visible = false;
	cursor_status = false;
	
	//mp.gui.chat.push('O nome '+mp.game.joaat(model)+' é! '+modelo+'');
});

function updateObject() {
    if (object == null) return;
    var model = object.model;
    var position = object.position;
    var rot = object.getRotation(2);
    var pitch = object.getPitch();
    object.destroy();
    object = mp.objects.new(model, position,
        {
            rotation: new mp.Vector3(0, 0, 0),
            alpha: 255,
            dimension: localplayer.dimension
        });
    object.setRotation(pitch, rot.y, rot.z, 2, true);
}

mp.events.add('endEditing', function () {
    object.destroy();
    object = null;
    editing = false;
});

mp.keys.bind(0x26, false, function () { // UP Arrow
    //mp.gui.chat.push("Old rot: " + new mp.Vector3(object.getRotation(2).x, object.getRotation(2).y, object.getRotation(2).z));
    if (chatopened || !editing) return;
    /*switch (editing_type_idx) {
        // pos x
        case 0:
            var pos = object.position;
            object.position = new mp.Vector3(pos.x + moving_speeds[moving_speed_idx], pos.y, pos.z);
            break;
        // pos y
        case 1:
            var pos = object.position;
            object.position = new mp.Vector3(pos.x, pos.y + moving_speeds[moving_speed_idx], pos.z);
            break;
        // pos z
        case 2:
            var pos = object.position;
            object.position = new mp.Vector3(pos.x, pos.y, pos.z + moving_speeds[moving_speed_idx]);
            break;
        // rot x
        case 3:
            var rot = object.getRotation(2);
            var pitch = object.getPitch();
            object.setRotation(pitch + moving_speeds[moving_speed_idx], rot.y, rot.z, 2, true);
            break;
        // rot y
        case 4:
            var rot = object.getRotation(2);
            var pitch = object.getPitch();
            object.setRotation(pitch, rot.y + moving_speeds[moving_speed_idx], rot.z, 2, true);
            break;
        // rot z
        case 5:
            var rot = object.getRotation(2);
            var pitch = object.getPitch();
            object.setRotation(pitch, rot.y, rot.z + moving_speeds[moving_speed_idx], 2, true);
            break;
    }*/
    //mp.gui.chat.push("New rot Fixes: " + new mp.Vector3(object.getRotation(2).x.toFixed(2), object.getRotation(2).y.toFixed(2), object.getRotation(2).z.toFixed(2)));
	if(toggle_rotation === false)
	{
		var pos = object.position;
		object.position = new mp.Vector3(pos.x, pos.y + moving_speeds[moving_speed_idx], pos.z);
	}
	else
	{
		var rot = object.getRotation(2);
        var pitch = object.getPitch();
        object.setRotation(pitch, rot.y + moving_speeds[moving_speed_idx], rot.z, 2, true);
	}
    updateObject();
});

mp.keys.bind(0x28, false, function () { // DOWN Arrow
    if (chatopened || !editing) return;
    /*switch (editing_type_idx) {
        // pos x
        case 0:
            var pos = object.position;
            object.position = new mp.Vector3(pos.x - moving_speeds[moving_speed_idx], pos.y, pos.z);
            break;
        // pos y
        case 1:
            var pos = object.position;
            object.position = new mp.Vector3(pos.x, pos.y - moving_speeds[moving_speed_idx], pos.z);
            break;
        // pos z
        case 2:
            var pos = object.position;
            object.position = new mp.Vector3(pos.x, pos.y, pos.z - moving_speeds[moving_speed_idx]);
            break;
        // rot x
        case 3:
            var rot = object.getRotation(2);
            var pitch = object.getPitch();
            object.setRotation(pitch - moving_speeds[moving_speed_idx], rot.y, rot.z, 2, true);
            break;
        // rot y
        case 4:
            var rot = object.getRotation(2);
            var pitch = object.getPitch();
            object.setRotation(pitch, rot.y - moving_speeds[moving_speed_idx], rot.z, 2, true);
            break;
        // rot z
        case 5:
            var rot = object.getRotation(2);
            var pitch = object.getPitch();
            object.setRotation(pitch, rot.y, rot.z - moving_speeds[moving_speed_idx], 2, true);
            break;
    }*/
	if(toggle_rotation === false)
	{
		var pos = object.position;
		object.position = new mp.Vector3(pos.x, pos.y - moving_speeds[moving_speed_idx], pos.z);
	}
	else
	{
		var rot = object.getRotation(2);
        var pitch = object.getPitch();
        object.setRotation(pitch, rot.y - moving_speeds[moving_speed_idx], rot.z, 2, true);
	}
    updateObject();
});

mp.keys.bind(0x25, false, function () { // LEFT Arrow
    if (chatopened || !editing) return;
	
	if(toggle_rotation === false)
	{
		var pos = object.position;
		object.position = new mp.Vector3(pos.x - moving_speeds[moving_speed_idx], pos.y, pos.z);
	}
	else
	{
		var rot = object.getRotation(2);
        var pitch = object.getPitch();
        object.setRotation(pitch - moving_speeds[moving_speed_idx], rot.y, rot.z, 2, true);
	}
	updateObject();
    //editing_type_idx--;
    //if (editing_type_idx < 0) editing_type_idx = editing_types.length - 1;
});

mp.keys.bind(0x27, false, function () { // RIGHT Arrow
    if (chatopened || !editing) return;
	
	if(toggle_rotation === false)
	{
		var pos = object.position;
		object.position = new mp.Vector3(pos.x + moving_speeds[moving_speed_idx], pos.y, pos.z);
	}
	else
	{
		var rot = object.getRotation(2);
        var pitch = object.getPitch();
        object.setRotation(pitch + moving_speeds[moving_speed_idx], rot.y, rot.z, 2, true);
	}
	updateObject();
    //editing_type_idx++;
    //if (editing_type_idx >= editing_types.length) editing_type_idx = 0;
});


mp.keys.bind(0x5A, false, function () { // Z Key
    if (chatopened || !editing) return;
	
	if(toggle_rotation === false)
	{
		var pos = object.position;
        object.position = new mp.Vector3(pos.x, pos.y, pos.z + moving_speeds[moving_speed_idx]);
	}
	else
	{
		var rot = object.getRotation(2);
        var pitch = object.getPitch();
        object.setRotation(pitch, rot.y, rot.z + moving_speeds[moving_speed_idx], 2, true);
	}
	updateObject();
});

mp.keys.bind(0x58, false, function () { // X Key
    if (chatopened || !editing) return;
	
	if(toggle_rotation === false)
	{
		var pos = object.position;
        object.position = new mp.Vector3(pos.x, pos.y, pos.z - moving_speeds[moving_speed_idx]);
	}
	else
	{
		var rot = object.getRotation(2);
        var pitch = object.getPitch();
        object.setRotation(pitch, rot.y, rot.z - moving_speeds[moving_speed_idx], 2, true);
	}
	updateObject();
});

mp.keys.bind(0x59, false, function () { // Y key
    if (chatopened || !editing) return;
    var rot = object.getRotation(2);
    var pitch = object.getPitch();
    var position = new mp.Vector3(object.position.x.toFixed(3), object.position.y.toFixed(3), object.position.z.toFixed(3));
    var rotation = new mp.Vector3(rot.x.toFixed(2), rot.y.toFixed(2), rot.z.toFixed(2));
    mp.events.callRemote('acceptEdit', modelo, position.x, position.y, position.z, rotation.x, rotation.y, rotation.z);
    object.destroy();
    object = null;
    editing = false;
});

mp.keys.bind(0x4E, false, function () { // N key
    if (chatopened || !editing) return;
    object.destroy();
    object = null;
    editing = false;
    mp.events.callRemote('cancelEdit');
});

mp.keys.bind(0x21, false, function () { // page up
    if (chatopened || !editing) return;
    moving_speed_idx++;
    if (moving_speed_idx >= moving_speeds.length) moving_speed_idx = 0;
});

mp.keys.bind(0x22, false, function () { // page down
    if (chatopened || !editing) return;
    moving_speed_idx--;
    if (moving_speed_idx < 0) moving_speed_idx = moving_speeds.length - 1;
});

mp.keys.bind(0x45, false, function () { // E key
    if (chatopened || !editing) return;
	if(toggle_rotation === false)
	{
		toggle_rotation = true;
	}
	else
	{
		toggle_rotation = false;
	}
});

function zoomLevel ()
{
	return mp.game.invoke('0x33E6C8EFD0CD93E9');
}

function pointingAt(distance)
{
	const camera = mp.cameras.new("gameplay");
    let position = camera.getCoord();
    let direction = camera.getDirection();
    let farAway = new mp.Vector3((direction.x * distance) + (position.x), (direction.y * distance) + (position.y), (direction.z * distance) + (position.z));

    let result = mp.raycasting.testPointToPoint(position, farAway, [1, 16]);

    return result;
}

mp.events.add('render', () => {

    if (object !== null)
	{
		mp.game.graphics.drawText(`~y~Controlers`, [0.5, 0.05], {
			font: 0,
			color: [255, 255, 255, 255],
			scale: [0.5, 0.5],
			outline: false
		});
		
        mp.game.graphics.drawText(`Y: Confirm~n~N: Cancel~n~Arrow's: Harkat Object Be Atraf`, [0.5, 0.1], {
			font: 0,
			color: [255, 255, 255, 255],
			scale: [0.3, 0.3],
			outline: false
		});
		
        mp.game.graphics.drawText(`~n~~n~~n~E: Switch between position and rotation`, [0.5, 0.1], {
			font: 0,
			color: [255, 255, 255, 255],
			scale: [0.3, 0.3],
			outline: false
		});  
        mp.game.graphics.drawText(`~n~~n~~n~~n~Page up & page down: Taghir Sorat Harkat Object: (${moving_speeds[moving_speed_idx]})`, [0.5, 0.1], {
			font: 0,
			color: [255, 255, 255, 255],
			scale: [0.3, 0.3],
			outline: false
		});   
        mp.game.graphics.drawText(`~n~~n~~n~~n~~n~X: Up ~n~ down: Z`, [0.5, 0.1], {
			font: 0,
			color: [255, 255, 255, 255],
			scale: [0.3, 0.3],
			outline: false
		});  
	}
});