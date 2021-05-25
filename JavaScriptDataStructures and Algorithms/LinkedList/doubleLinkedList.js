class DoubleNode {
	constructor(element) {
		this.previous = undefined;
		this.element = element;
		this.next = undefined;
	}
}

const defaultEquals = (a, b) => {
	return a === b;
};

class DoubleLinkedList {
	constructor(equalFn = defaultEq) {
		this.count = 0;
		this.head = undefined;
        this.tail = undefined;
		this.equalFn = equalFn;
	}
	push(element) {
		let node = new DoubleNode(element);
		let current;
		if (this.head == null) {
			this.head = node;
			node.previous = this.head;
		} else {
			current = this.head;
			while (current.next != null) {
				current = current.next;
			}
			current.next = node;
			node.previous = current;
            this.tail = node;
			
		}
        this.count++;
        return this.node;
	}

	getElement(index) {
		if (index >= 0 && index < this.count && index != null) {
			let node = this.head;
			for (let i = 0; i < index && node != null; i++) {
				node = node.next;
			}
			return node;
		} else {
			return undefined;
		}
	}
	getIndexOf(element) {
		if (element != null) {
			let current = this.head;
			let count = 0;
			while (this.count >= count) {
				if (this.equalFn(current.element, element)) {
					return count;
				}
				current = current.next;
				count++;
			}
		} else {
			return -1;
		}
	}

	removeAt(index) {
		if (index >= 0 && index <= this.count && index != null) {
			let node = this.head;
			if (index == 0) {
				this.head == node.next;
			} else {
				let previous = this.getElement(index - 1);
				let current = previous.next;
				previous.next = current.next;
				this.count--;
			}
			return true;
		} else {
			return undefined;
		}
	}

	insertAt(index, element) {
        console.log(index, this.count);
		if (index >= 0 && index <= this.count && index != null) {
			let node = new DoubleNode(element);
			if (index == 0 || index == this.count) {
				this.push(element);
			} 
            else {
				let previous = this.getElement(index - 1);
				let current = previous.next;
				previous.next = node;
				node.next = current;
                current.previous = node;
				node.previous = previous;
			}
			this.count++;
			return true;
		}
		return false;
	}

	getCount() {
		return this.count;
	}

	isEmpty() {
		return this.count == 0 ? true : false;
	}
	getHead() {
		return this.head;
	}
	removeElement(element) {
		let index = this.getIndexOf(element);
		if (index >= 0) {
			this.removeAt(index);
		} else {
			return undefined;
		}
		return true;
	}
}

let list = new DoubleLinkedList(defaultEquals);
list.push(1);
list.push(2);
list.insertAt(2,4);
let node = list.getElement(1);
console.log(node);
let previous = node.previous;
let next = node.next;
console.log(node.element , previous.element , next.element);

