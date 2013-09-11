describe("AddressBook JS Controller Test", function () {
    it("Customer controller can be instantiated", function () {
        var customerController = new CustomerController();
        expect(customerController).toBeDefined();
    });
    
    it("Employee controller can be instantiated", function () {
        var employeeController = new EmployeeController();
        expect(employeeController).toBeDefined();
    });
    
    it("Manager controller can be instantiated", function () {
        var managerController = new ManagerController();
        expect(managerController).toBeDefined();
    });
    
    it("Sales Person controller can be instantiated", function () {
        var salesPersonController = new SalesPersonController();
        expect(salesPersonController).toBeDefined();
    });
});

describe("AddressBook JS Model Test", function () {
    it("Customer model can be instantiated", function () {
        var customer = new Customer();
        expect(customer).toBeDefined();
    });

    it("Employee model can be instantiated", function () {
        var employee = new Employee();
        expect(employee).toBeDefined();
    });

    it("Manager model can be instantiated", function () {
        var manager = new Manager();
        expect(manager).toBeDefined();
    });

    it("Sales Person model can be instantiated", function () {
        var salesPerson = new SalesPerson();
        expect(salesPerson).toBeDefined();
    });
});


