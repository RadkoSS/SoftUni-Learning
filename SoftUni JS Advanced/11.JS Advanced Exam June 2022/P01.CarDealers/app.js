window.addEventListener("load", solve);

function solve() {
   const submitButton = document.getElementById(`publish`);
   submitButton.addEventListener(`click`, publishInfo);

   const tableBody = document.getElementById(`table-body`);
   const soldCarsList = document.getElementById(`cars-list`);
   const profitMade = document.getElementById(`profit`);

   let make = document.getElementById(`make`);
   let model = document.getElementById(`model`);
   let productionYear = document.getElementById(`year`);
   let fuelType = document.getElementById(`fuel`);
   let originalPrice = document.getElementById(`original-cost`);
   let sellingPrice = document.getElementById(`selling-price`);

  function publishInfo(e) {
    e.preventDefault();

    if (make.value === `` || model.value === `` || productionYear.value === `` || fuelType.value === `` || originalPrice.value === `` || sellingPrice.value === ``) {
      return;
    }

    let originalPriceToNum = Number(originalPrice.value);
    let sellingPriceToNum = Number(sellingPrice.value);

    if (originalPriceToNum > sellingPriceToNum) {
      return;
    }

    let tableRow = elementFactory(`tr`);
    tableRow.className = `row`;
    let tdMake = elementFactory(`td`, `${make.value}`);
    let tdModel = elementFactory(`td`, `${model.value}`);
    let tdYear = elementFactory(`td`, `${productionYear.value}`);
    let tdFuel = elementFactory(`td`, `${fuelType.value}`);
    let tdOrigPrice = elementFactory(`td`, `${originalPrice.value}`);
    let tdSellPrice = elementFactory(`td`, `${sellingPrice.value}`);
    let tdButtons = elementFactory(`td`);

    let editButton = elementFactory(`button`, `Edit`);
    editButton.className = `action-btn edit`;
    editButton.addEventListener(`click`, editInfo);

    let sellButton = elementFactory(`button`, `Sell`);
    sellButton.className = `action-btn sell`;
    sellButton.addEventListener(`click`, sellCar);

    tableRow.appendChild(tdMake);
    tableRow.appendChild(tdModel);
    tableRow.appendChild(tdYear);
    tableRow.appendChild(tdFuel);
    tableRow.appendChild(tdOrigPrice);
    tableRow.appendChild(tdSellPrice);
    
    tdButtons.appendChild(editButton);
    tdButtons.appendChild(sellButton);
    
    tableRow.appendChild(tdButtons);

    tableBody.appendChild(tableRow);
    
    make.value = ``;
    model.value = ``;
    productionYear.value = ``;
    fuelType.value = ``;
    originalPrice.value = ``;
    sellingPrice.value = ``;

    function editInfo(e){
      e.preventDefault();
      
      make.value = tdMake.textContent;
      model.value = tdModel.textContent;
      productionYear.value = tdYear.textContent;
      fuelType.value = tdFuel.textContent;
      originalPrice.value = tdOrigPrice.textContent;
      sellingPrice.value = tdSellPrice.textContent;

      tableBody.removeChild(tableRow);
    }
  
    function sellCar(e){
      e.preventDefault();
      
      let liWithCar = elementFactory(`li`);
      liWithCar.className = `each-list`;

      let modelSpan = elementFactory(`span`, `${tdMake.textContent} ${tdModel.textContent}`);
      let yearSpan = elementFactory(`span`, `${tdYear.textContent}`);
      
      let currentCarProfit = Number(tdSellPrice.textContent) - Number(tdOrigPrice.textContent);

      let priceSpan = elementFactory(`span`, `${currentCarProfit}`)

      liWithCar.appendChild(modelSpan);
      liWithCar.appendChild(yearSpan);
      liWithCar.appendChild(priceSpan);

      soldCarsList.appendChild(liWithCar);
      updateTotalProfit();

      tableBody.removeChild(tableRow);
    }
  }

  function updateTotalProfit(){
    let allCarsInList = Array.from(soldCarsList.children);
    
    let totalProfit = 0;

    allCarsInList.forEach(carLi => {
      totalProfit += Number(carLi.children[2].textContent);
    });

    profitMade.textContent = `${totalProfit.toFixed(2)}`;
  }

  function elementFactory(tag, content = ``){
    const element = document.createElement(tag);
    element.textContent = content;

    return element;
  }
}