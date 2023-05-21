let characterid = -1;
let requests = null;
let members= null;
let ranks = null;
let lab = undefined;
let vehicles = null;

let factions = null;
let faction = null;	

$( "#factioncreate" ).click(function() {
	var name = $('#factionname').val();
	var type = $("input[name='factiontype']:checked").val();
	
	mp.trigger('createFaction', name,type);
	
	var createFactionButton = document.getElementById('factionCreateModal');
	createFactionButton.classList.add('disabled');
	createFactionButton.disabled = true;
});



function editMember(member,rank) {
	
	characterid = member;
	$("input[name='optradio'][value='"+rank+"']").attr('checked', 'checked');
}



$( "#saverank" ).click(function() {
	
	var newrank = $('input[name=optradio]:checked').val()-1;
	mp.trigger('EditCharacterRank', characterid,newrank);
	var a = "#member"+characterid;
	$(a).text(ranks[newrank].name);
	
});



$('#fname').on('input',function(e){
    document.getElementById('savefname').classList.remove('d-none');
});

$( "#savefname" ).click(function() {
	this.classList.add('d-none');
	var name = $('#fname').val();
	mp.trigger('factionEditName',name);
});


$('#rank1').on('input',function(e){
    document.getElementById('save1').classList.remove('d-none');
});

$('#rank2').on('input',function(e){
    document.getElementById('save2').classList.remove('d-none');
});

$('#rank3').on('input',function(e){
    document.getElementById('save3').classList.remove('d-none');
});

$('#rank4').on('input',function(e){
    document.getElementById('save4').classList.remove('d-none');
});

$('#rank5').on('input',function(e){
    document.getElementById('save5').classList.remove('d-none');
});

$('#rank6').on('input',function(e){
    document.getElementById('save6').classList.remove('d-none');
});

$('#rank7').on('input',function(e){
    document.getElementById('save7').classList.remove('d-none');
});

$('#rank8').on('input',function(e){
    document.getElementById('save8').classList.remove('d-none');
});

$('#rank9').on('input',function(e){
    document.getElementById('save9').classList.remove('d-none');
});

$('#rank10').on('input',function(e){
    document.getElementById('save10').classList.remove('d-none');
});
$('#rank11').on('input',function(e){
    document.getElementById('save11').classList.remove('d-none');
});


$( "#save1" ).click(function() {
	this.classList.add('d-none');
	var name = $('#rank1').val();
	mp.trigger('EditRankName' , 0 , name);
});


$( "#save2" ).click(function() {
	this.classList.add('d-none');
	var name = $('#rank2').val();
	mp.trigger('EditRankName' , 1 , name);
});

$( "#save3" ).click(function() {
	this.classList.add('d-none');
	var name = $('#rank3').val();
	mp.trigger('EditRankName' , 2 , name);
});

$( "#save4" ).click(function() {
	this.classList.add('d-none');
	var name = $('#rank4').val();
	mp.trigger('EditRankName' , 3 , name);
});

$( "#save5" ).click(function() {
	this.classList.add('d-none');
	var name = $('#rank5').val();
	mp.trigger('EditRankName' , 4 , name);
});

$( "#save6" ).click(function() {
	this.classList.add('d-none');
	var name = $('#rank6').val();
	mp.trigger('EditRankName' , 5 , name);
});

$( "#save7" ).click(function() {
	this.classList.add('d-none');
	var name = $('#rank7').val();
	mp.trigger('EditRankName' , 6 , name);
});

$( "#save8" ).click(function() {
	this.classList.add('d-none');
	var name = $('#rank8').val();
	mp.trigger('EditRankName' , 7 , name);
});

$( "#save9" ).click(function() {
	this.classList.add('d-none');
	var name = $('#rank9').val();
	mp.trigger('EditRankName' , 8 , name);
});

$( "#save10" ).click(function() {
	this.classList.add('d-none');
	var name = $('#rank10').val();
	mp.trigger('EditRankName' , 9 , name);
});
$( "#save11" ).click(function() {
	this.classList.add('d-none');
	var name = $('#rank11').val();
	mp.trigger('EditRankName' , 10 , name);
});
function populateFactionsList(inventoryJson ,leader, member, invite) {

		
		factions = JSON.parse(inventoryJson);
		
		
		// Get the item containers
		let orgContainer = document.getElementById('orglist');
		let ilegalContainer = document.getElementById('ilegallist');
		
		// Clear the children
		while(orgContainer.firstChild) {
			orgContainer.removeChild(orgContainer.firstChild);
		}
			
		// Clear the children
		while(ilegalContainer.firstChild) {
			ilegalContainer.removeChild(ilegalContainer.firstChild);
		}
		
		let createFactionButton = document.getElementById('factionCreateModal');
		// Add the text to the header
		if(leader > 0)
		{
			createFactionButton.classList.add('disabled');
			createFactionButton.disabled = true;
		}
			

		
		for(let i = 0; i < factions.length; i++) {
			// Get each item
			let item = factions[i];
			
			var row = document.createElement('tr');
			var col1 = document.createElement('td');
			var col2 = document.createElement('td');
			var col3 = document.createElement('td');
			var col4 = document.createElement('td');
			
			col1.textContent = item.name;
			col2.textContent = GetFactionTypeName(item.type);
			col3.textContent = item.members;
	
			col4.className = 'text-right';
			
			let optionContainer = document.createElement('button');
			optionContainer.textContent = 'Udji';
			optionContainer.className = "btn btn-sm buttonjoin";
			if(member == 0)
			{
				if(invite == 0)
				{
					optionContainer.textContent = 'Udji';
					optionContainer.className = "btn btn-sm buttonjoin";
					optionContainer.onclick = (function() {
						
						mp.trigger('factionJoin', item.id);
						this.textContent = 'Otkazi';
						this.classList.remove('btn-success');
						this.classList.remove('buttonjoin');
						//this.classList.add('btn-danger');
						
						this.onclick = (function() {
							mp.trigger('factionDecline');
							
							this.textContent = 'Udji';
							this.classList.add('btn-success');
							this.classList.add('buttonjoin');
							this.classList.remove('btn-danger');
							this.disabled = true;
							
							var otherbuttons = document.getElementsByClassName('buttonjoin');
							for (var i = 0; i < otherbuttons.length; ++i) 
							{
								otherbuttons[i].classList.add('btn-success');
								otherbuttons[i].classList.remove('disabled');
								otherbuttons[i].disabled = false;
							}
						
						});
						
						var otherbuttons = document.getElementsByClassName('buttonjoin');
						for (var i = 0; i < otherbuttons.length; ++i) 
						{
							otherbuttons[i].classList.remove('btn-success');
							otherbuttons[i].classList.add('disabled');
							otherbuttons[i].disabled = true;
						}
						
					});
				}
				if(invite > 0)
				{
					if(invite == item.id)
					{
						optionContainer.textContent = 'Otkazi';
						optionContainer.className = "btn btn-sm";
						optionContainer.onclick = (function() {
							
							mp.trigger('factionDecline');
							
						});
					}
					else
					{	
						optionContainer.classList.remove('btn-success');
						optionContainer.classList.add('disabled');
						optionContainer.disabled = true;
					}
				}
			}
			else
			{
					if(member == item.id)
					{
						optionContainer.textContent = 'Napusti';
						optionContainer.className = "btn btn-sm";
						optionContainer.onclick = (function() {
							
							mp.trigger('factionLeave', item.id);
							
							
							this.textContent = 'Udji';
							this.classList.add('btn-success');
							this.classList.add('buttonjoin');
							this.classList.remove('btn-danger');
							
							var otherbuttons = document.getElementsByClassName('buttonjoin');
							for (var i = 0; i < otherbuttons.length; ++i) 
							{
								otherbuttons[i].classList.add('btn-success');
								otherbuttons[i].classList.remove('disabled');
								otherbuttons[i].disabled = false;
							}
							
						});
					}
					else
					{	
						optionContainer.classList.remove('btn-success');
						optionContainer.classList.add('disabled');
						optionContainer.disabled = true;
					}
			}
	
			row.appendChild(col1);
			row.appendChild(col2);
			row.appendChild(col3);
			col4.appendChild(optionContainer);
			row.appendChild(col4);
			
			

			if(item.type == 1 || item.type == 2 || item.type == 3 || item.type == 6 || item.type == 7)
			{
				orgContainer.appendChild(row);
			}
			if (item.type == 4 || item.type == 5)
			{
				ilegalContainer.appendChild(row);
			}
			
		}			
}



function GetFactionTypeName(tip)
{
	var type = "unknown";	
	if(tip == 1){ type = "Law";}
	else if(tip == 2){ type = "EMS";}
	else if(tip == 3){ type = "NEWS";}
	else if(tip == 5){ type = "Mafia";}	
	else if(tip == 4){ type = "Gang";}
	else if(tip == 7){ type = "Government";}
	else if(tip == 6){ type = "Mehanicar";}
	else { type = "unknown";}
	return type;
}





function populateFactionMenu(factionInfo,requestsList ,membersList, ranksList) {

		faction = JSON.parse(factionInfo);
		requests = JSON.parse(requestsList);
		members = JSON.parse(membersList);
		ranks = JSON.parse(ranksList);
		
		
		// Get the item containers

		let membersContainer = document.getElementById('members');
		let requestsContainer = document.getElementById('requests');
		
		// Clear the children
		

		for(let i = 0; i < members.length; i++) {
			// Get each item
			let item = members[i];
			
			var row = document.createElement('tr');
			var col1 = document.createElement('td');
			var col2 = document.createElement('td');
			var col3 = document.createElement('td');

			var col5 = document.createElement('td');
			
			col1.textContent = item.name;
			col2.innerHTML  = '<span  id="member' + item.character + '">'+ ranks[item.rank].name + '</span>  <button class="btn btn-sm btn-info" onclick="editMember(' + item.character + ',' + (item.rank+1) + ')" data-toggle="modal" data-target="#RankModal" >Edit</button>';


			let optionContainer = document.createElement('button');
			optionContainer.textContent = 'Kick';
			optionContainer.className = "btn btn-sm";
			optionContainer.onclick = (function() {
						mp.trigger('factionCharacterKick', item.character,item.rank);
						this.parentNode.parentNode.remove();
			});
			

			
			row.appendChild(col1);
			row.appendChild(col2);
			row.appendChild(col3);

			col5.appendChild(optionContainer);
			row.appendChild(col5);
			
			
			membersContainer.appendChild(row);
		}
		
		

		for(let i = 0; i < requests.length; i++) {
			// Get each item
			let item = requests[i];
			
			var row = document.createElement('tr');
			var col1 = document.createElement('td');
			var col2 = document.createElement('td');
			var col3 = document.createElement('td');
			var col4 = document.createElement('td');
			var col5 = document.createElement('td');
			
			col1.textContent = item.name;
			col2.textContent = item.level;
			col3.textContent = item.phone;
	
			
			
			let optionContainer = document.createElement('button');
			optionContainer.textContent = 'Approve';
			optionContainer.className = "btn btn-sm btn-success";
			optionContainer.onclick = (function() {
						mp.trigger('factionJoinApprove', item.character);
						this.parentNode.parentNode.remove();
			});
			
			
			let optionContainer2 = document.createElement('button');
			optionContainer2.textContent = 'Decline';
			optionContainer2.className = "btn btn-sm";
			optionContainer2.onclick = (function() {
						mp.trigger('factionJoinDecline', item.character);
						this.parentNode.parentNode.remove();
			});
			
			
			row.appendChild(col1);
			row.appendChild(col2);
			row.appendChild(col3);
			col4.appendChild(optionContainer);
			row.appendChild(col4);
			col5.appendChild(optionContainer2);
			row.appendChild(col5);
			
			
			requestsContainer.appendChild(row);
		}
		
		
		
		$('#factionName').text( faction[0].name);
	//	document.getElementById('factionVault').textContent = faction.cash;
		$('#factionMembers').text(faction[0].members);
		$('#factionType').text(GetFactionTypeName(faction[0].type));
		document.getElementById('fname').value = faction[0].announce;
	//	document.getElementById('factionLeader').textContent = faction.leader;
		

		
		
		let rank1 = document.getElementById('rank1');
		let rank2 = document.getElementById('rank2');
		let rank3 = document.getElementById('rank3');
        let rank4 = document.getElementById('rank4');
		let rank5 = document.getElementById('rank5');
		let rank6 = document.getElementById('rank6');
		let rank7 = document.getElementById('rank7');
		let rank8 = document.getElementById('rank8');
        let rank9 = document.getElementById('rank9');
		let rank10 = document.getElementById('rank10');
		let rank11 = document.getElementById('rank11');
		

		rank1.value = ranks[0].name; 
		rank2.value = ranks[1].name; 
		rank3.value = ranks[2].name; 
		rank4.value = ranks[3].name; 
		rank5.value = ranks[4].name; 
		rank6.value = ranks[5].name; 
		rank7.value = ranks[6].name; 
		rank8.value = ranks[7].name; 
		rank9.value = ranks[8].name; 
		rank10.value = ranks[9].name;
		rank11.value = ranks[10].name;
		
		
		let rankedit1 = document.getElementById('setrank1');
		let rankedit2 = document.getElementById('setrank2');
		let rankedit3 = document.getElementById('setrank3');
        let rankedit4 = document.getElementById('setrank4');
		let rankedit5 = document.getElementById('setrank5');
		let rankedit6 = document.getElementById('setrank6');
		let rankedit7 = document.getElementById('setrank7');
		let rankedit8 = document.getElementById('setrank8');
        let rankedit9 = document.getElementById('setrank9');
		let rankedit10 = document.getElementById('setrank10');
		let rankedit11 = document.getElementById('setrank11');
		

		rankedit1.textContent = ranks[0].name; 
		rankedit2.textContent = ranks[1].name; 
		rankedit3.textContent = ranks[2].name; 
		rankedit4.textContent = ranks[3].name; 
		rankedit5.textContent = ranks[4].name; 
		rankedit6.textContent = ranks[5].name; 
		rankedit7.textContent = ranks[6].name; 
		rankedit8.textContent = ranks[7].name; 
		rankedit9.textContent = ranks[8].name; 
		rankedit10.textContent = ranks[9].name;
		rankedit11.textContent = ranks[10].name;
		

}



function closeFactions() {
	mp.trigger('closeFactions');
}



