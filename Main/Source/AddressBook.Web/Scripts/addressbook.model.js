function Customer(id,
					firstName,
					lastName,
					dateOfBirth,
					gender,
					age,
					race,
					education,
					createdOn,
					lastModifiedOn) {
	var customer = {
		Id: id,
		FirstName: firstName,
		LastName: lastName,
		DateOfBirth: dateOfBirth,
		Gender: gender,
		Age: age,
		Race: race,
		Education: education,
		CreatedOn: createdOn,
		LastModifiedOn: lastModifiedOn
	};
	return customer;
}

function Employee(id,
					firstName,
					lastName,
					dateOfBirth,
					region,
					department,
					branch,
					hireDate,
					approvedOvertime,
					createdOn,
					lastModifiedOn) {
	var employee = {
		Id: id,
		FirstName: firstName,
		LastName: lastName,
		DateOfBirth: dateOfBirth,
		Region: region,
		Department: department,
		Branch: branch,
		HireDate: hireDate,
		ApprovedOvertime: approvedOvertime,
		CreatedOn: createdOn,
		LastModifiedOn: lastModifiedOn
	};
	return employee;
}

function Manager(id,
					firstName,
					lastName,
					dateOfBirth,
					region,
					department,
					branch,
					hireDate,
					spendingLimit,
					createdOn,
					lastModifiedOn) {
	var manager = {
		Id: id,
		FirstName: firstName,
		LastName: lastName,
		DateOfBirth: dateOfBirth,
		Region: region,
		Department: department,
		Branch: branch,
		HireDate: hireDate,
		SpendingLimit: spendingLimit,
		CreatedOn: createdOn,
		LastModifiedOn: lastModifiedOn
	};
	return manager;
}

function SalesPerson(id,
						firstName,
						lastName,
						dateOfBirth,
						region,
						department,
						branch,
						hireDate,
						weeklySalesGoal,
						createdOn,
						lastModifiedOn) {
	var salesPerson = {
		Id: id,
		FirstName: firstName,
		LastName: lastName,
		DateOfBirth: dateOfBirth,
		Region: region,
		Department: department,
		Branch: branch,
		HireDate: hireDate,
		WeeklySalesGoal: weeklySalesGoal,
		CreatedOn: createdOn,
		LastModifiedOn: lastModifiedOn
	};
	return salesPerson;
}

