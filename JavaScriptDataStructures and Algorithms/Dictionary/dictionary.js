const stringFnEqual = (item) => {
	let returnValue;
	if (item == null) {
		returnValue = "NULL";
	} else if (item == undefined) {
		returnValue = "UNDEFINED";
	} else if (typeof item == "string" || item instanceof String) {
		returnValue = `${item}`;
	} else {
		returnValue = `${item}`;
	}

    return returnValue;
};

class Dictionary {
	constructor(stringFnEqual = stringFnEqual) {
		this.toStrFn = stringFnEqual;
		this.table = {};
	}

	set(key, value) {
		if (key != null && value != null) {
			if (!this.has(key)) {
				this.table[key] = new ValuePair(key, value);
			}
			return true;
		}
		return false;
	}
	remove(key) {
		if (this.has(key)) {
			delete this.table[key];
			return true;
		}
		return false;
	}
	has(key) {
		if (this.table.hasOwnProperty(this.toStrFn(key))) {
			return true;
		} else {
			return false;
		}
	}
	get(key) {
		if (this.has(key)) {
			return this.table[this.toStrFn(key)];
		}
	}
	clear() {
		this.table = {};
	}
	size() {
		let count = 0;
		for (let key in this.table) {
			if (this.has(key)) {
				count++;
			}
		}
		return count;
	}
	isEmpty() {
		return this.count == 0 ? true : false;
	}
	keys() {
		let keys = [];
		for (let key in this.table) {
			if (this.has(key)) {
				keys.push(key);
			}
		}
		return keys;
	}

	values() {
		let values = [];
		for (let key in this.table) {
			if (this.has(key)) {
				values.push(this.table[key].value);
			}
		}
		return values;
	}

	keyValues() {
		let values = [];
		for (let key in this.table) {
            console.log(key)
			if (this.has(key)) {
				values.push(this.table[key]);
			}
		}
		return values;
	}

	forEach(callBackFn) {
		let valuePairs = this.keyValues();
        console.log(valuePairs)
		for (let i = 0; i < this.size(); i++) {
			let result = callBackFn(valuePairs[i].key, valuePairs[i].value);
			if (result == false) {
				break;
			}
		}
	}
}

class ValuePair {
	constructor(key, value) {
		this.key = key;
		this.value = value;
	}
	toString() {
		return `[#${this.key}:${this.value}]`;
	}
}


let dictionary = new Dictionary(stringFnEqual);
dictionary.set(0,'first')
dictionary.set(1,'second')
dictionary.forEach((key,value)=>console.log(key,value))
