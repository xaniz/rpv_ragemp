function createTraffic() {
  if (e.interval) {
    clearInterval(e.interval)
    delete e.interval
    return
  }
  e.streamedCars = []
  e.interval = setInterval(() => {
    // onStreamOut()
    let p = sp
    if (mp.vehicles.length >= 500) return
    if (e.streamedCars.length >= 30) return
    let rp = inFrontOf(Object.assign({}, p), Math.random() * 360, 200)
    let {outPosition, outHeading} = mp.game.pathfind.getClosestVehicleNodeWithHeading(rp.x, rp.y, rp.z, new mp.Vector3(0,0,0), 0, 4, 3, 0)
    if (mp.game.gameplay.isPositionOccupied(outPosition.x,outPosition.y,outPosition.z, 5,false, true, false, false, false, 0,false)) {
      mp.gui.chat.push('#fff000Skipping, position occupied')
      return
    }
    if (mp.game.system.vdist(outPosition.x,outPosition.y,outPosition.z, p.x,p.y,p.z) < 200) {
      return mp.gui.chat.push('#000fffSkipping, position too close < 200')
    }
    let vehModel = vehs[Math.floor(Math.random() * vehs.length)]
    e.streamedCars.push({id: e.streamedCars.length, pos: outPosition, heading: outHeading, model: vehModel})
    let v = mp.vehicles.new(
      mp.game.joaat(vehModel), outPosition, {
      color: [[Math.random()*255, Math.random()*255, Math.random()*255], [Math.random()*255,Math.random()*255,Math.random()*255]],
      dimension: player.dimension
    })
    v.setHeading(outHeading)
    let ped = mp.peds.new(0, outPosition, 0, player.dimension)
    ped.setIntoVehicle(v.handle, -1)
    ped.taskVehicleDriveWander(v.handle, 20, 786603)
    ped.car = v.id
    msg(e.streamedCars.length-1 +': pos: ' + JSON.stringify(outPosition) + ', heading: '+ outHeading)
  }, 0)
}