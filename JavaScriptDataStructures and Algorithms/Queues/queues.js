// Queue is a FIFO data-strucuture

module.exports.Queue =  class Queue {
	constructor() {
		this.count = 0;
		this.onFirst = 0;
		this.items = {};
	}

	enqueue(value) {
		this.items[this.count] = value;
		this.count++;
	}
	dequeue() {
		if (this.isEmpty()) {
			return undefined;
		}
		let value = this.items[this.onFirst];
		delete this.items[this.onFirst];
		this.onFirst++;
		return value;
	}
	peek() {
		if (this.isEmpty()) {
			return undefined;
		}
		return this.items[this.onFirst];
	}
	getSize() {
		return this.count - this.onFirst;
	}

	isEmpty() {
		this.getSize() == 0 ? true : false;
	}
}


// let queue = new Queue();
// queue.enqueue(1)
// queue.enqueue(2)
// queue.enqueue(3)
// console.log(queue.dequeue())