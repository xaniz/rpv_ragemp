let purchasedAmount = 1;
let selected = undefined;
let selectedname = undefined;


function populateBusinessItems(businessItemsJson, businessName,returnto, multiplier) {
	
		// Initialize the values
		purchasedAmount = 1;
		selected = undefined;
		selectedname = undefined;


		// Get items to show
		let businessItemsArray = JSON.parse(businessItemsJson);
		let header = document.getElementById('header');
		let content = document.getElementById('content');
		let options = document.getElementById('options');
		
		// Clear the children
		while(content.firstChild) {
			content.removeChild(content.firstChild);
		}
		// Clear the children
		while(options.firstChild) {
			options.removeChild(options.firstChild);
		}
		
		// Show business name
		header.textContent = businessName;
		
		for(let i = 0; i < businessItemsArray.length; i++) {
			
			let item = businessItemsArray[i];
			
			
			let itemContainer = document.createElement('div');

			let itemBody = document.createElement('div');
			let itemDescription = document.createElement('div');
			let itemVariation = document.createElement('div');
			let itemAmmount = document.createElement('div');
			let itemPrice = document.createElement('div');
			let buttonPlus = document.createElement('div');
			let buttonMinus = document.createElement('div');
			let itemImage = document.createElement('img');
			
			itemContainer.classList.add('card-1', 'bg-dark', 'text-white', 'mb-2', 'col-md-12','panel-row');

			itemBody.classList.add('card-body-1');
			//itemDescription.classList.add('col-md-6');
			//itemVariation.classList.add('col-md-3');
			


			
			buttonPlus.classList.add('btn', 'btn-info','btn-lg','col-md-11');
			buttonMinus.classList.add('btn', 'btn-danger','btn-lg','col-md-11');
			
			let price = Math.round(item.price * multiplier);
			
			

			
			itemAmmount.innerHTML = '<b>Kolicina:</b> ' + purchasedAmount;
			itemPrice.innerHTML = '<b>Cena:</b> ' + price + '$<br>';
			itemDescription.innerHTML = '<b>'+item.name+ '</b><br>';
			itemDescription.append(itemPrice);
			itemDescription.append(itemAmmount);
			
			
			buttonPlus.textContent = '';
			buttonMinus.textContent = '';

			
			itemContainer.onclick = (function() {
				// Check if the item is not selected
				if(selected != i) {
					
					if(selected != undefined) {
						let previousSelected = document.getElementsByClassName('panel-row')[selected];
						previousSelected.classList.remove('bg-secondary');
						previousSelected.classList.add('bg-dark');
					}
					
					let currentSelected = document.getElementsByClassName('panel-row')[i];
					currentSelected.classList.add('bg-secondary');
					currentSelected.classList.remove('bg-dark');
					
					// Store the item and initialize the amount
					purchasedAmount = 1;
					selected = i;
					selectedname = item.name;
					
					// Update the element's text
					itemAmmount.innerHTML = '<b>Kolicina:</b> ' + purchasedAmount;
					itemPrice.innerHTML = '<b>Cena:</b> ' + price * purchasedAmount+ '$<br>';
					
				}
			});
			
			
			buttonPlus.onclick = (function() {
				purchasedAmount++;
				if(purchasedAmount <= 10) 
				{
					itemAmmount.innerHTML = '<b>Kolicina:</b> ' + purchasedAmount;
					itemPrice.innerHTML = '<b>Cena:</b> ' + price * purchasedAmount+ '$<br>';
				}
				else
				{
					purchasedAmount--;
				}
			});
			
			buttonMinus.onclick = (function() {
				
				purchasedAmount--;
				if(purchasedAmount >= 0) 
				{
					itemAmmount.innerHTML = '<b>Kolicina:</b> ' + purchasedAmount;
					itemPrice.innerHTML = '<b>Cena:</b> ' + price * purchasedAmount+ '$<br>';
				}
				else
				{
					purchasedAmount = 0;
				}
			});
			
			
			
			content.appendChild(itemContainer);
			itemContainer.appendChild(itemBody);
			
			
			itemBody.appendChild(itemDescription);
			itemBody.appendChild(itemVariation);
			
			itemVariation.appendChild(buttonPlus);
			itemVariation.appendChild(buttonMinus);
		}
		let purchaseButton = document.createElement('div');

		
		purchaseButton.classList.add('btn', 'btn-warning', 'btn-lg', 'btn-block');

		
		purchaseButton.textContent = "Kupi";

		

		purchaseButton.onclick = (function() {
			// Check if the user purchased anything
			if(selected != undefined) {
				mp.trigger('purchaseItem',returnto,selectedname ,selected, purchasedAmount);
			}
		});

		
		options.appendChild(purchaseButton);

		
}


function CloseMenu() {
	mp.trigger('Closeshopmenu');
}