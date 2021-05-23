//Some new functonalities of es6
let numbers = [1,2,3,4,5,6,7,8,8];

//for of iterates the numbers
for (const n of numbers) {
    //console.log(n);
}

//for in iterates index
for (const key in numbers) {
//console.log(key)
}

// Array has new @iterator property which we can access thorugh Symbols.iterator property as follows

let iterator = numbers[Symbol.iterator]();
for (const n of iterator) {
    //console.log(n)
}

//Three ways to reterive iterators //Entries gives both keys and values in array , keys give only keys and values give only values
 
//entries
let entries = numbers.entries();
for (const n of entries) {
}

//keys
let keys = numbers.keys();
for (const n of keys) {
}

//values
let values = numbers.values();
for (const n of values) {
}

//Array.of method constructs a new array from the values passed to it.
numbers = Array.of(1);

numbers = Array.of(...[1,2,3,4,5,6]);

//fill method fills the array with dummy values

numbers.fill(0);
let fillArray = new Array(10);
fillArray.fill(0);

//Custom Sorting
numbers = [1,2,3,4,5,6,7,8,8];
console.log(numbers.sort(compare));




function compare(a,b){
    console.log(a,b);
    if(a%2==0){
        return -1
    }
    if(b%2 == 0){
        return 1
    }

    return 0
}

//find and findIndex



