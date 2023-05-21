<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

uiGlobal_Browsers.execute("LoadPlayersW(" + JSON.stringify(menu_item_list) + ");");

function LoadPlayersW(menu_item_list) {
   for (var i = 0; i < menu_item_list.length; i++) {
     var suspect = menu_item_list[i].suspect;
     var stars = menu_item_list[i].stars;
     $("#players tbody").append("<tr><td>" + stars + "</td><td>" + suspect + "</td></tr>");
   }
}