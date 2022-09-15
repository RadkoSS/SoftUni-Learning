function calculatePrice(fruit, grams, pricePerKilo){

    let weightInKg = grams / 1000
    let totalPrice = weightInKg * pricePerKilo

    return `I need $${totalPrice.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`
}

console.log(calculatePrice('apple', 1563, 2.35))