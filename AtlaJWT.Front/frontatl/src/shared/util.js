import Swal from "sweetalert2";
import req from "../services/req";


const columns =
    [[{
        dataField: "id", text: "Id"
    },
    {
        dataField: "userName", text: "Nome"
    },
    {
        dataField: "age", text: "Idade"
    }],
    [
        {
            dataField: "userName", text: "Nome"
        },
        {
            dataField: "age", text: "Idade"
        },
    ],
    [
        {
            dataField: "userName", text: "Nome"
        }
    ]]

export function showModalSwal(message, type) {
    Swal.fire({
        icon: type,
        title: message
    });
}

export function validateFields(name, age, password)
{
    if(name === "" || password === "" || age === "")
    {
        showModalSwal("Não deixe nada em branco", "warning" )
        return true;
    }

    return false;
}

export function selectColumnsTypesByRole() {
    if (localStorage.getItem("Role") === "Admin") {
        return columns[0]
    }
    else if (localStorage.getItem("Role") === "User") {
        return columns[1]
    }
    return columns[2];
}

export function verifyIsNullOrEmpty(user, password) {
    if (user === "" || password === "") {
        return true;
    }

    return false;
}
