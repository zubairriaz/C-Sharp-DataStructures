class Node {
	constructor(element) {
		this.next = undefined;
		this.element = element;
	}
}

const defaultEquals = (a, b) => {
	return a === b;
}

class LinkedList {
	constructor(equalFn = defaultEq) {
		this.count = 0;
		this.head = undefined;
		this.equalFn = equalFn;
	}
	push(element) {
		let node = new Node(element);
		let current;
		if (this.head == null) {
			this.head = node;
		} else {
			current = this.head;
			while (current.next != null) {
				current = current.next;
			}
			current.next = node;
			this.count++;
		}
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
    getIndexOf(element){
        if(element != null){
          let current = this.head;
          let count = 0;
          while(this.count >= count){
              console.log(current.element , element);
              if(this.equalFn(current.element,element)){
                  return count;
              }
              current = current.next;
              count++;
          }
        }else{
            return -1
        }
    }

	removeAt(index) {
		if (index >= 0 && index < this.count && index != null) {
			let node = this.head;
			if (index == 0) {
				this.head == node.next;
			} else {
				let previous = this.getElement(index - 1);
				let current = previous.next;
				previous.next = current.next;
			}
		} else {
			return undefined;
		}
	}

	insertAt(index, element) {
		if (index >= 0 && index < this.count && index != null) {
			let node = new Node(element);
			if (index == 0) {
				let current = this.head;
				node.next = current;
				this.head = node;
			} else {
				let previous = this.getElement(index - 1);
				let current = previous.next;
				previous.next = node;
				node.next = current;
			}
			this.count++;
            return true
		}
        return false;
	}

	getCount() {
		return this.count;
	}

	isEmpty() {
		return this.count == 0 ? true : false;
	}
}


let list = new LinkedList(defaultEquals);
list.push(1);
list.push(2);
list.push(4);


console.log(list.getIndexOf(4))