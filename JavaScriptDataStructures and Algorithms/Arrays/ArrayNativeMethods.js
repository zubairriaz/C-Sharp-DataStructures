// Some less commonly used array methods

//Concat
//every
//Some
//IndexOF
//lastIndexOf
//foreach
//map
//filter
//reverse
//reduce
//join
//slice
//toString
//valueOf

let numbersEven = [2, 4, 6, 8];
let numbersOdd = [1, 3, 5, 7, 9];

//Concat it used for concating two arrays
let numbers = numbersEven.concat(...numbersOdd);
numbers.sort();
console.log(numbers);

//every , iterates the items of the array until false is returned
let resultFull = numbers.every((item) => item % 2 == 0);
let resultEven = numbersEven.every((item) => item % 2 == 0);
let resultOdd = numbersOdd.every((item) => item % 2 == 0);

//Some iterates all items until true is returned
resultFull = numbers.some(item => item%2 == 0);
resultEven = numbersEven.some((item) => item % 2 == 0);
resultOdd = numbersOdd.some((item) => item % 2 == 0);

//Index of given the index of specific element in the array
console.log(numbers.indexOf(4));


//last index of returns the last index of the element in the array
let tempArray = [1,2,3,4,5,5,6,5];
console.log(tempArray.lastIndexOf(5));

//reverse is used to reverse an array
console.log(tempArray.reverse());


//join is used to join array elments into string
console.log(tempArray.join(','))

//slice is used to create multiple array of single array (1) if undefined is provided as a start index 0 will be used. (2) use negative index from last like -2 represent second last
console.log(tempArray.slice(2,-2))

// reduce takes two numbers and out out the result
console.log(numbers.reduce((a,b)=>a+b,0));

// valueof just like to String

console.log(numbers.valueOf())


