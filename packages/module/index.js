mp.events.add({
    'entityCreated' : (entity) => {
        if(entity.type == 'vehicle') {
            entity.doors = [0,0,0,0,0,0,0]
        }
    },
    'server.vehicles.sync.doors' : (player, vehicle, doors) => {
        vehicle.doors = JSON.parse(doors);
        mp.players.call(player.streamedPlayers, 'client.vehicles.sync.doors', [vehicle, JSON.stringify(vehicle.doors)]);
        player.call('client.vehicles.sync.doors', [vehicle, JSON.stringify(vehicle.doors)]);
    },
    'server.vehicles.get.sync.doors' : (player, vehicle) => {
        if(vehicle.doors != undefined && typeof vehicle.doors == 'object') {
            player.call('client.vehicles.sync.doors', [vehicle, JSON.stringify(vehicle.doors)]);
        }
    }
})

