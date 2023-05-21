function notify(type, layout, message, time) {
    var types = ['alert', 'error', 'success', 'information', 'warning'];
    var layouts = ['top', 'topLeft', 'topCenter', 'topRight', 'center', 'centerLeft', 'centerRight', 'bottom', 'bottomLeft', 'bottomCenter', 'bottomRight'];
    var icons = ['<i class=""><div class="border"></div><img src="UI/notification/error.png" width="25px"></i></i>', '<i class=""><div class="border"></div><img src="UI/notification/error.png" width="25px"></i>', '<i class=""><div class="border"></div><img src="UI/notification/success.png" width="25px"></i></i>', '<i class=""><div class="border"></div><img src="UI/notification/info.png" width="25px"></i>', '<i class=""><div class="border"></div><img src="UI/notification/warning.png" width="25px" ></i>']
    message = '<div class="text">'+icons[type]+message+'</div>';
    new Noty({
        type: types[type],
        layout: layouts[layout],
        theme: 'fivestar',
        text: message,
        timeout: time,
        progressBar: true,
        animation: {
            open: 'noty_effects_open',
            close: 'noty_effects_close'
        }
    }).show();
}