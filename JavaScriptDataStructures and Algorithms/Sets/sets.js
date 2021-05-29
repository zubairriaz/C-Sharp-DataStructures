class CSet {
	constructor(items=[]) {
        this.items = {};
        items.forEach(item=>this.addItem(item));
	}

	hasElement(item) {
		if (Object.keys(this.items).includes(item)) {
			return true;
		}
		return false;
	}

	addItem(item) {
		if (!this.hasElement(item)) {
			this.items[item] = item;
		}
	}

	delete(item) {
		if (this.hasElement(item)) {
			delete this.items[item];
		}
	}

	clear() {
		this.items = {};
	}

	size() {
		return Object.values(this.items).length;
	}

	values() {
		let values = [];
		for (let key in this.items) {
			if (this.items.hasOwnProperty(key)) {
				values.push(key);
			}
		}
		return values;
	}

	union(otherSet) {
		let tempSet = new CSet();
		this.values().forEach((item) => tempSet.addItem(item));
		otherSet.values().forEach((item) => tempSet.addItem(item));
		return tempSet;
	}

	intersection(otherSet) {
        console.time("test")
		let tempSet = new CSet();
		this.values().forEach((item) => {
			if (otherSet.hasElement(item)) {
				tempSet.addItem(item);
			}
		});
        console.timeEnd("test")
		return tempSet;
	}

    ImprIntersection(otherSet){
        console.time("test1")
        let biggerSet = this;
        let smallerSet = otherSet;
        if(otherSet.values.length - this.values.length > 0){
             biggerSet = otherSet;
             smallerSet = this;
        }
        let tempSet = new CSet();
		smallerSet.values().forEach((item) => {
			if (biggerSet.hasElement(item)) {
				tempSet.addItem(item);
			}
		});
		console.timeEnd("test1")
        return tempSet;
        
    }
    
    isSubsetOf(otherSet){
        if(this.size() > otherSet.size()){
            return false;
        }
        let isSubset =  true;
        this.values().forEach(item=>{
            if(!otherSet.hasElement(item)){
                isSubset =  false
            }
        })
        return isSubset;
    }
    
	difference(otherSet) {
        let tempSet = new CSet();
		this.values().forEach((item) => {
			if (!otherSet.hasElement(item)) {
				tempSet.addItem(item);
			}
		});
		return tempSet;
    }
}

let csetA = new CSet([1,2,3,4,5,6,7,8,9,10,11,12,14,15,16,17,18,19,20]);
let csetB = new CSet([1,2]);

console.log(csetA.ImprIntersection(csetB));
console.log(csetA.intersection(csetB));


