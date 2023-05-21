var StockGov = new Vue({
    el: ".main",
    data: {
		active: false,
		style: 0,
		name: "Weapon shop",
		items: null,
    },
    methods:{
        gostyle: function(index) {
            this.style = index;
        },
		open: function(id){
            this.menu = id;
        },
		buy: function(index) {
			mp.trigger("client::buyweapon", index);
		},
		exit: function() {
			mp.trigger("Hide_Crafting_System");
		},
    }
});