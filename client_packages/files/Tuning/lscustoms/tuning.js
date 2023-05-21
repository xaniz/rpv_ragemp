function disable(json){
    json.forEach((item, i, arr) => {
        //console.log(item);
        $('#'+item).hide();
    });
}
function set(speed, brakes, boost, clutch){
    $('#speed_bar').attr('value', speed);
    $('#brakes_bar').attr('value', brakes);
    $('#boost_bar').attr('value', boost);
    $('#clutch_bar').attr('value', clutch);
}
/*$('a').hover((e) => {
    console.log('hover:'+e.currentTarget.id)
}, () => {});*/
$('a').click((e) => {
    //console.log('click:'+e.currentTarget.id);
    mp.trigger('tpage', e.currentTarget.id);
});
$('div.item').hover((e) => hover(e.currentTarget.id), () => {});
$('div.item').click((e) => click(e.currentTarget.id));
function click(id){
    if(!id) return;
    //console.log('click:'+id);
    mp.trigger('tclk', id);
}
function hover(id){
    //console.log('hover:'+id);
    mp.trigger('thov', id);
}
// [['ID', Price], ['ID', Price], ...]
// OR
// ['ID', Price]
function price(obj){
    if(Array.isArray(obj[0])){
        obj.forEach((item, i, arr) => {
            $(`#${item[0]} p`)[1].innerHTML = item[1];
        });
    } else {
        $(`#${obj[0]} p`)[1].innerHTML = obj[1];
    }
}
// [['ID','Name',Price], ['ID','Name',Price], ...]
// OR
// ['ID','Name',Price]
function add(obj){
    if(Array.isArray(obj[0])){
        obj.forEach((item, i, arr) => {
            $('.content_box').append(`<div id='${item[0]}' class='item'><p>${item[1]}</p><p>${item[2]}</p></div>`);
            $('#'+item[0]).hover((e) => hover(e.currentTarget.id), () => {});
            $('#'+item[0]).click((e) => click(e.currentTarget.id));
        });
    } else {
        $('.content_box').append(`<div id='${obj[0]}' class='item'><p>${obj[1]}</p><p>${obj[2]}</p></div>`)
        $('#'+obj[0]).hover((e) => hover(e.currentTarget.id), () => {});
        $('#'+obj[0]).click((e) => click(e.currentTarget.id));
    }
}
function show(state){
    if(!state){
        $('body').hide();
    } else {
        $('body').show();
    }
}