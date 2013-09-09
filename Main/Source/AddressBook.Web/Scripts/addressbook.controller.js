function CustomerController() {
    this.Get = function (id, callback) {
        $.ajax({
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            url: "/api/customer/" + id,
            "sAjaxDataProp": "data.inner",
            success: function (data) {
                callback.apply(this, [data]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
            }
        });
    }
}

function EmployeeController() {
    this.Get = function (id, callback) {
        $.ajax({
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            url: "/api/employee/" + id,
            "sAjaxDataProp": "data.inner",
            success: function (data) {
                callback.apply(this, [data]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
            }
        });
    }
}

function ManagerController() {
    this.Get = function (id, callback) {
        $.ajax({
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            url: "/api/manager/" + id,
            "sAjaxDataProp": "data.inner",
            success: function (data) {
                callback.apply(this, [data]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
            }
        });
    }
}

function SalesPersonController() {
    this.Get = function (id, callback) {
        $.ajax({
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            url: "/api/salesperson/" + id,
            "sAjaxDataProp": "data.inner",
            success: function (data) {
                callback.apply(this, [data]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
            }
        });
    }
}

function PeopleController() {
    this.GetAll = function (callback) {
        this.response = null;
        $.ajax({
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            url: "/api/people",
            "sAjaxDataProp": "data.inner",
            success: function (data) {
                callback.apply(this, [data]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
            }
        });
    }
}