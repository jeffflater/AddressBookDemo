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
    };
    this.Post = function (model, callback) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            url: "/api/customer",
            data: JSON.stringify(model),
            "sAjaxDataProp": "data.inner",
            success: function (data) {
                callback.apply(this, [data]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
            }
        });
    };
    this.Delete = function (id, callback) {
        $.ajax({
            type: 'DELETE',
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
    };
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
    };
    this.Post = function (model, callback) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            url: "/api/employee",
            data: JSON.stringify(model),
            "sAjaxDataProp": "data.inner",
            success: function (data) {
                callback.apply(this, [data]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
            }
        });
    };
    this.Delete = function (id, callback) {
        $.ajax({
            type: 'DELETE',
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
    };
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
    };
    this.Post = function (model, callback) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            url: "/api/manager",
            data: JSON.stringify(model),
            "sAjaxDataProp": "data.inner",
            success: function (data) {
                callback.apply(this, [data]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
            }
        });
    };
    this.Delete = function (id, callback) {
        $.ajax({
            type: 'DELETE',
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
    };
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
    };
    this.Post = function (model, callback) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            url: "/api/salesperson",
            data: JSON.stringify(model),
            "sAjaxDataProp": "data.inner",
            success: function (data) {
                callback.apply(this, [data]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
            }
        });
    };
    this.Delete = function (id, callback) {
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
    };
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
    };
}

function RelationshipController() {
    this.GetAll = function (id, typeId, callback) {
        this.response = null;
        $.ajax({
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            url: "/api/relationship/" + id + "/" + typeId,
            "sAjaxDataProp": "data.inner",
            success: function (data) {
                callback.apply(this, [data]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                callback.apply(this, null);
            }
        });
    };
    this.Post = function (model, callback) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            url: "/api/relationship",
            data: JSON.stringify(model),
            "sAjaxDataProp": "data.inner",
            success: function (data) {
                callback.apply(this, [data]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
            }
        });
    };
}