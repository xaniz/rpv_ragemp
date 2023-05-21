var numberChanger = new Vue({
  el: '#app',
  data: {
    active: true,
	number: null,
	style: 0,
	typenum: 1,
	btns: [false,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false],
  },
  mounted: function() {
	  document.addEventListener('keyup', this.keyUp);
  },
  methods: {
	keyUp(event) {
      if(event.keyCode == 27) this.exit();
    },
	gostyle: function(index) {
            this.style = index;
			this.number = null;
	},
	change() {
		// alert(this.number.toUpperCase()) //Тест
		mp.trigger("changeNumber", this.number.toUpperCase(), this.typenum);
		mp.trigger("Hide_Crafting_System");
	},
	changecustom(type) {
		// alert(this.number.toUpperCase()) //Тест
		mp.trigger("changeNumber", this.number.toUpperCase(), type);
		mp.trigger("Hide_Crafting_System");
	},
	changerand() {
		mp.trigger("changeNumberRandom");
	},
	randomnumber8: function(id) {
		let ind = this.btns.indexOf(true);
		if (ind > -1) this.btns[ind] = false;
		this.btns[id] = true;
		this.typenum=id;
		this.active=false;
		this.active=true;
		
		this.number = "";
	
		var whitelist = "ABEKMHOPCTYX";
		var whitelistnum = "0123456789";
		
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		
		this.number += whitelistnum.charAt(Math.floor(Math.random() * 10));
		this.number += whitelistnum.charAt(Math.floor(Math.random() * 10));
		this.number += whitelistnum.charAt(Math.floor(Math.random() * 10));
		
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		// mp.trigger("MinusMoneyForRandom");
	},
	randomnumber7: function(id) {
		this.number = "";
	
		var whitelist = "ABEKMHOPCTYX";
		var whitelistnum = "0123456789";
		
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		// this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		
		this.number += whitelistnum.charAt(Math.floor(Math.random() * 10));
		this.number += whitelistnum.charAt(Math.floor(Math.random() * 10));
		this.number += whitelistnum.charAt(Math.floor(Math.random() * 10));
		
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		let ind = this.btns.indexOf(true);
		if (ind > -1) this.btns[ind] = false;
		this.btns[id] = true;
		this.typenum=id;
		this.active=false;
		this.active=true;
		// mp.trigger("MinusMoneyForRandom");
	},
	randomnumber6: function(id) {
		this.number = "";
	
		var whitelist = "ABEKMHOPCTYX";
		var whitelistnum = "0123456789";
		
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		// this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		
		this.number += whitelistnum.charAt(Math.floor(Math.random() * 10));
		this.number += whitelistnum.charAt(Math.floor(Math.random() * 10));
		this.number += whitelistnum.charAt(Math.floor(Math.random() * 10));
		
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		let ind = this.btns.indexOf(true);
		if (ind > -1) this.btns[ind] = false;
		this.btns[id] = true;
		this.typenum=id;
		this.active=false;
		this.active=true;
		// this.number += whitelist.charAt(Math.floor(Math.random() * 12));
		// mp.trigger("MinusMoneyForRandom");
	},
	exit()
	{
		mp.trigger("Hide_Crafting_System");
	}
  }
})

function gen() {
	var number = "";
	
	var whitelist = "ABEKMHOPCTYX";
	var whitelistnum = "0123456789";
	
	number += whitelist.charAt(Math.floor(Math.random() * 12));
	
	number += whitelistnum.charAt(Math.floor(Math.random() * 10));
	number += whitelistnum.charAt(Math.floor(Math.random() * 10));
	number += whitelistnum.charAt(Math.floor(Math.random() * 10));
	
	number += whitelist.charAt(Math.floor(Math.random() * 12));
	number += whitelist.charAt(Math.floor(Math.random() * 12));
	number += whitelist.charAt(Math.floor(Math.random() * 12));
	
	console.log(number)
	
}