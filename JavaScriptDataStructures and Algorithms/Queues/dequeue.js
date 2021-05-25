
const Queue = require('./queues');

module.exports.Dequeue = class Dequeue extends Queue.Queue{

    addFirst(value){
      if(this.isEmpty){
         this.addLast(value);
      }
      else if(this.onFirst > 0){
          this.onFirst--;
          this.items[this.onFirst] = value;
          this.onFirst--;
      }
      else{
          for(i=this.count; i >0 ; i--){
              this.items[i] = this.items[i+1]
          }
          this.items[0] = value
          this.onFirst = 0
      }
    }

    addLast(value){
        this.items[this.count] = value
        this.count++;
        return value;
    }

    removeLast(){
        if(this.isEmpty()){
            return undefined;
        }
        this.count--;
        let value = this.items[this.count];
        delete this.items[this.count];
        return value;
    }

}


// let queue = new Dequeue();
// queue.addLast(1);
// queue.addFirst(2);
// queue.addLast(3);
// queue.addFirst(4);

// console.log(queue.dequeue())