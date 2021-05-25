const Dequeue = require('./dequeue');

function palindromeChecker(sValue){
    let isPalindrom = true;
    if(!sValue.trim() ){
        return false;
    }
     sValue = sValue.toLowerCase().split(' ').join('');
    let dequeue = new Dequeue.Dequeue();
    sValue.split('').forEach(element => {
        dequeue.addLast(element);
    });
    while(dequeue.getSize() > 0 && isPalindrom){
        let firstChar =  dequeue.dequeue();
        let lastChar =  dequeue.removeLast();
        if(firstChar != lastChar){
            isPalindrom = false;
        }
    }

    return isPalindrom;

}

console.log(palindromeChecker('abccbaa'))
