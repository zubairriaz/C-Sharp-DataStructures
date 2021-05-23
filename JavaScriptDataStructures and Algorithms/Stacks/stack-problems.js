const Stack = require('./stack')

function decimalToBinary(dNumber, base){
    let remStack = new Stack.Stack();
    let number = dNumber;
    let returnedString = '';

    while(number > 0){
        remStack.push(Math.floor(number%base));
        number = Math.floor(number / base);
    }
    while(!remStack.isEmpty()){
        let value = remStack.pop()
        console.log(value);
        returnedString = `${returnedString}${value}`
    }
    return returnedString;
}

console.log(decimalToBinary(1010,8))