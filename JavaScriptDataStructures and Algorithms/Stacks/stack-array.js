class Stack {
	constructor() {
		this.items = [];
	}

	getSize() {
		return this.items.length;
	}
	peek() {
		return this.items[this.items.length - 1];
	}
	pop() {
		return this.items.pop();
	}
	push(value) {
		this.items.push(value);
	}

    isEmpty(){
        return this.items.length == 0 ? true :false
    }
    clear(){
        this.items = []
    }
}

let stack = new Stack();
stack.push(1);
stack.push(2);
console.log(stack.peek());
console.log(stack.isEmpty())
console.log(stack.getSize())

