function solve() {
  let wordsToTransform = document.getElementById('text').value.split(` `);
  let convention = document.getElementById(`naming-convention`).value;
  let output = document.getElementById(`result`);
  let result = ``;

  if (convention === `Camel Case`) {
    result += wordsToTransform[0].toLowerCase();
    for (let index = 1; index < wordsToTransform.length; index++) {
      result += wordsToTransform[index][0].toUpperCase() + wordsToTransform[index].substring(1).toLowerCase();
    }
  } else if (convention === `Pascal Case`) {
    result += wordsToTransform[0][0].toUpperCase() + wordsToTransform[0].substring(1).toLowerCase();
    for (let index = 1; index < wordsToTransform.length; index++) {
      result += wordsToTransform[index][0].toUpperCase() + wordsToTransform[index].substring(1).toLowerCase();
    }
  }
  else {
    result = `Error!`;
  }

  output.textContent = result;
}