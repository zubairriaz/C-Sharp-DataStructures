const _items = new WeakMap();
const _count = new WeakMap();
module.exports.Stack =  class Stack {
	constructor() {
		_items.set(this,{});
		_count.set(this,0);
        
	}

	push(value) {
        let items =  _items.get(this);
        let count = _count.get(this);
        items[count] = value;
		count++;
        _count.set(this,count);
	}
	pop() {
		if (this.isEmpty()) {
			return undefined;
		}
        let count = _count.get(this);
		count--;
        let items =  _items.get(this);
        let value = items[count];
		delete items[count];
        _count.set(this,count);
		return value;
	}
	peek() {
        if(this.isEmpty()){
            return undefined;
        }
        let count = _count.get(this);
		count--;
        let items =  _items.get(this);
        _count.set(this,count);
        return items[count];
	}
	getSize() {
        let items =  _items.get(this);
		return Object.keys(items).length;
	}

	clear() {
        let count = _count.get(this);

		_items.set(this,{});
		 count = 0;
        _count.set(this,count);

	}
	isEmpty() {
        let count = _count.get(this);

		return count == 0 ? true : false;
	}
}

// let stack = new Stack();
// stack.push(1);
// stack.push(2);
// stack.push(3);
// console.log(stack.peek());
// console.log(stack.isEmpty());
// console.log(stack.getSize());

// console.log(Object.getOwnPropertyNames(stack))
// let symbol = Object.getOwnPropertySymbols(stack);

// console.log(symbol.length)
