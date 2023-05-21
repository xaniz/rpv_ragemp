const chokidar = require('chokidar')
const fs = require('fs')

let watcher = chokidar.watch(__dirname)
let players = {}

mp.events.addCommand('hot', player => {
  if (players[player.id]) {
    delete players[player.id]
    console.log('Hot loader: ' + player.name + ' stopped listening')
    player.outputChatBox('[Hot Loader] Stopped Clientside')
    return
  }
  player.outputChatBox('[Hot Loader] Started Clientside')
  console.log('Hot loader: ' + player.name + ' is listening')
  players[player.id] = player
  player.eval('hotLoaderRender = null')
})

mp.events.add('playerQuit', p => {
  if (players[p.id] != null) delete players[p.id]
})

let lastEval
watcher.on('ready', () => {
  
  watcher.on('change', path => {
    if (!path.endsWith('.js') || path.endsWith('hot-loader\\index.js')) return
    // 1 sec delay to fix sending code twice
    if (lastEval && (Date.now() - lastEval) < 1000 ) return
    lastEval = Date.now()
    // console.log(`Hot loader: Changed >> ${path}`)
    
    let file = fs.readFileSync(path)
    file = file.toString()

    if (path.endsWith('hot-loader\\test-s.js')) {
      try {
        eval(file)
      } catch (error) {
        console.error('[HOT LOADER] Error: ', error)
      }
      return
    }

    if (Object.keys(players).length <= 0
      || !path.endsWith('hot-loader\\test-c.js')) return

    Object.keys(players).forEach(id => {
      players[id].eval(`
      try {
        if (hotLoaderRender && hotLoaderRender.destroy)
          hotLoaderRender.destroy()
        ${file}
      } catch (e) {
        hotLoaderRender = new mp.Event('render', ()=> {
          mp.game.graphics.drawText('[hot-loader] Error: ', [0.15,0.35], {
            font: 0,
            scale: [0.65, 0.65],
            color: [255,0,0,255]
          })
          mp.game.graphics.drawText(e, [0.25,0.40], {
            font: 0,
            scale: [0.40, 0.40],
            color: [0,255,0,255]
          })
        })
        setTimeout(()=> {
          hotLoaderRender.destroy()
        }, 5000)
      }`)
    })
  })
})