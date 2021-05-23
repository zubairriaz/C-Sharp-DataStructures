const averageTempearureJan = 0.4;
const averageTempearureFeb = 0.5;
const averageTempearureMarch = 0.6;
averageTempearureMarchApril = 0.7;

let averageTempArray = [];
averageTempArray[0] = averageTempearureJan;
averageTempArray[1] = averageTempearureFeb;
averageTempArray[2] = averageTempearureMarch;
averageTempArray[3] = averageTempearureMarchApril;

//console.log(averageTempArray);

//Creating Arrays in javascript

let daysOfWeek = new Array();
daysOfWeek = new Array(7);
daysOfWeek = new Array('Tue','Wed','Thursday','Fri','Sat','Sun');

//Best Practise
daysOfWeek = [];
daysOfWeek = ['Tue','Wed','Thursday','Fri','Sat','Sun'];

//iterating an array
 for(let i = 0 ; i< daysOfWeek.length; i++){
     //console.log(daysOfWeek[i])
 }

 const fibionci = [];
 fibionci[0] = 1;
 fibionci[1] = 1;

 for(let i = 2; i<20; i++){
    fibionci[i] =  fibionci[i-1] + fibionci[i-2];
 }

 fibionci.forEach(element => {
    //console.log(element);
 });

 //Adding Elements in array
let numbers = [1,2,3,4,5,6,7,8,9];
numbers[numbers.length] = 10;
//Adds element to the end of array
numbers.push(11);
numbers.push(12,13);


//Adds element to the start of array
Array.prototype.insertIntoFirstPosition = function(value){
    for(let i = this.length ; i>0 ; i--){
        this[i] = this[i-1]
    }
    this[0] = value;
}

numbers.insertIntoFirstPosition(-1);

//We have built in unshift method for this purposes
numbers.unshift(-2,-3);


// removing elements from the array
// removes the last element rom the array   
numbers.pop();
//To remove the element from the start of array

Array.prototype.removeFromBegining = function(){
    let returnedArray =[]
    for(let i = 0 ; i < this.length ; i++){
        this[i] = this[i+1];
    }
    for(let i = 0 ; i<this.length; i++ ){
        if(this[i] !== undefined){
            returnedArray.push(this[i])
        }
    }
    return returnedArray
}

numbers = numbers.removeFromBegining();


let number = numbers.shift()

console.log(numbers);

//splice for adding and removing items form array

numbers.splice(0,2);

console.log(numbers);

numbers.splice(0,0,-1,-2,-3,-4)

console.log(numbers);
