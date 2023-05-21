const chat =
{
	size: 0,
    container: null,
    input: null,
    enabled: false,
    active: true,
    timer: null,
    alpha: 1,
    previous: [],
    hide_chat: 60000, // in milliseconds
    openChatEvent: 84,
    maxCharactersBeforeCustomSplit: 9999, // Not used

    current: 0
}


const chatAPI =
{
	push: (args) =>
	{
		
        let arr = args.split("(/\)");
        let d = new Date();
            d.setHours(d.getHours() + d.getTimezoneOffset()/60 - 4);

            if(arr.length == 1) {
                arr = [(d.getHours() + ':' + ((d.getMinutes() < 10) ? '0' : '') + d.getMinutes()),'<font style="color: orange !important;"></font>',arr[0]];
            }
		chat.size++;
		if (chat.size >= 50)
		{
			chat.container.children(":first").remove();
        }
		


        chat.container.append('<li ><span class="name">' + arr[1] + '</span><span class="msg">' + arr[2] + '</span></li>');
        chat.container.scrollTop(9999);
        show();
		hide();
	},
	clear: () =>
	{
        chat.container.html("");
        chat.previous = [];
	},
	activate: (toggle) =>
	{
        if (!toggle) enableChatInput(false);
	},
	show: (toggle) =>
	{
		if(toggle) {
            $("#chat").show();
        } else $("#chat").hide();
	}
}


let api = {"chat:push": chatAPI.push, "chat:clear": chatAPI.clear, "chat:activate": chatAPI.activate, "chat:show": chatAPI.show}; 

for(let fn in api)
{
	mp.events.add(fn, api[fn]);
}

function hideChat(enable)
{
	if(enable) {
        $("#chat").show();
    } else $("#chat").hide();
	
}
function enableChatInput(enable)
{
    if(enable == "true") {
       
        chat.input.val('');
		$('#chat_msg').fadeIn(100);
		$('#chat_msg').focus();
		show();
		chat.current = 0;
	
    } else {
        chat.input.val('');
		$('#chat_msg').fadeOut(100);
		$('#chat_msg').val('');
		//hide();
        //chat.input.fadeOut();
    }
	

    chat.enabled = (enable == "true");
}
function hide() {
	if(chat.alpha == 1) {
		if(chat.timer != null) clearTimeout(chat.timer);
		chat.timer = setTimeout(function () {
			chatvar.css("opacity", 1);
		}, 30000);
	}
}
function show() {
    clearTimeout(chat.timer);
    $("#chat").css("opacity", 0.92);
    $(".background").css("opacity", 0.1);
//	$("#chat_messages").css("overflow",'overlay');
}
function previous() {
    if(!chat.enabled) return false;
    if(!chat.previous.length) return false;

    if((chat.previous.length - chat.current) < 0) 
	{

		return false;

	}

    chat.current++;
	chat.input.val(chat.previous[chat.previous.length - chat.current]);
	$("#chat_msg").get(0).setSelectionRange(10000,10000);
}
function next() {
    if(!chat.enabled) return false;
    if(!chat.previous.length) return false;
    if(chat.current == 1) return chat.input.val('');
	

    chat.current--;
    chat.input.val(chat.previous[chat.previous.length - chat.current]);
	
	$("#chat_msg").get(0).setSelectionRange(10000,10000);
}

function sendMsg() {
    let msg = chat.input.val();

    if(msg.length > 0 && msg.length <= 200) {
        if(msg[0] == '/') {
            mp.invoke("command", msg.substring(1));
        } else { mp.trigger("Send_ToServer", msg); hide(); }

        if(chat.previous.length >= 20) chat.previous.splice(0, 1);
		
		
		
        chat.previous.push(msg);
    } else if(msg.length > 200) {}
}

$("body").on('input', '#chat_msg', function() {
    if(!chat.enabled) return $(this).val('');

    let value = $(this).val();

    if(value.length > 200) $(this).val(value.substring(0, 200));
});
$(document).ready(function() {
    chat.input = $("#chat_msg");
    chat.container = $("#chat ul#chat_messages");
    hide();
});
