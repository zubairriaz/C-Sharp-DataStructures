class DoubleNode {
	constructor(element) {
		this.previous = undefined;
		this.element = element;
		this.next = undefined;
	}
}

class DoublyLinkedList {
	constructor() {
		this.head = undefined;
		this.tail = undefined;
		this.count = 0;
	}

	push(element) {
		let node = new DoubleNode(element);
		if ((this.head == null)) {
			this.head = node;
			node.previous = this.head;
			this.tail = node;
		} else {
			let current = this.head;
			while (current.next != null) {
				current = current.next;
			}
			current.next = node;
			node.previous = current;
			this.tail = node;
		}
		this.count++;
	}

	getElementAt(index) {
		if (index >= 0 && index < this.count) {
			let count = 0;
			let node = this.head;
			while (count <= index) {
				node = node.next;
				count++;
			}
			return node;
		} else {
			return undefined;
		}
	}

	insertAt(index, element) {
		if (index >= 0 && index < this.count) {
			let node = new DoubleNode(element);
			if (index == 0) {
				if (this.head == null) {
					this.head = node;
					this.tail = node;
				} else {
					let current = this.head;
					node.next = current;
					current.previous = node;
					this.head = node;

				}
			}else if(index == this.count -1){
			          let current = this.tail;
					  current.next = node;
					  node.previous = current;
					  this.tail = node;

			} 
			else {
				let previous = this.getElementAt(index - 1);
				let current = previous.next;
				previous.next = node;
				node.next = current;
				current.previous = node;
				node.previous = previous;
				
			}
			this.count++;
		}
	}

	removeAt(index) {
		if (index >= 0 && index < this.count) {
			if (index == 0) {
				let current = this.head;
				let next = current.next;
				if (this.count == 1) {
					this.tail == undefined;
				}
				this.head = next;
				this.head.previous = undefined;
			} else if (index == this.count - 1) {
				let current = this.tail;
				let previous = current.previous;
				previous.next = undefined;
				this.tail = previous;
			} else {
				let current = this.getElementAt(index);
				let previous = current.previous;
				let next = current.next;
				previous.next = next;
				next.previous = previous;
			}

			this.count--;
		}
	}

	getCount() {
		return this.count;
	}

	isEmpty() {
		this.count == 0 ? true : false;
	}
	getHead() {
		return this.head;
	}
	getTail() {
		return this.tail;
	}
}



let list = new DoublyLinkedList();
list.push(1);
list.push(2);
list.insertAt(0,3)
list.insertAt(0,4)
list.removeAt(0)
list.removeAt(2)


console.log(list.getHead().element);
console.log(list.getTail().element);
console.log(list.getCount());