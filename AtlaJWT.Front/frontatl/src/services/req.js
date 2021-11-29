import axios from 'axios'

const url = "https://localhost:44382/";
class Req {

    login = (obj) => {
        return axios({
            method: 'post',
            url: `${url}api/User/Login`,
            data: JSON.stringify(obj),
            headers: {
                'Content-Type': "application/json"
            }
        })
    }

    getAllUser = () => {

        return axios.get(`${url}api/User/GetAll`, {
            headers: {
                'Content-Type': "application/json",
                'Authorization': 'Bearer ' + localStorage.getItem("JWT_Token")
            },
        })
    }

    updateUserRegistered = (obj) => {
        return axios({
            method: 'post',
            url: `${url}api/User/Update`,
            data: JSON.stringify(obj),
            headers: {
                'Content-Type': "application/json",
                'Authorization': 'Bearer ' + localStorage.getItem("JWT_Token")
            }
        })
    }
}

export default new Req();