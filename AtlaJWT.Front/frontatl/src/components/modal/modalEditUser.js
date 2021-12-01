import React from "react";
import { Modal, Button } from 'react-bootstrap';
import { Input, Label } from "reactstrap";
import { showModalSwal, validateFields } from '../../shared/util'
import req from "../../services/req";

class ModalEditUser extends React.Component {
    state = {
        userName: "",
        password: "",
        age: 0,
        showModal: false
    }

    //Método que faz a atualização do usuário
    updateUser = () => {
        const { age, userName, password } = this.state;

        if(validateFields(userName, age, null))
        {
            return;
        }

        const obj = {
            "id": this.props.user.id,
            "idUserInfo": this.props.user.idUserInfo,
            "userName": userName,
            "age": age
        }

        req.updateUserRegistered(obj).then(x => {
          const { data, status } = x;

          if(status === 200)
          {
                this.props.closeModalEdit();
                showModalSwal("Usuário editado com sucesso", "success");
          }
          
        }).catch(x => {
            showModalSwal("Erro ao editar usuário", "error");
            this.props.closeModalEdit();

        })
    }

    componentDidMount = () => {
        if (this.props.user !== undefined) {
            this.setState({
                showModal: this.props.showModalEdit,
                userName: this.props.user.userName,
                age: this.props.user.age
            })
        }
    }

    render() {
        return (<Modal show={this.props.showModalEdit} onHide={() => this.props.closeModalEdit()}>
            <Modal.Header closeButton>
                <Modal.Title>Editar</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Label>Novo nome de Usuário</Label>
                <Input type="text"
                    id="user"
                    name="user"
                    placeholder="Usuário"
                    value={this.state.userName}
                    onChange={(e) => this.setState({ userName: e.target.value })}
                />

                <Label>Nova idade</Label>
                <Input
                    type="number"
                    id="idade"
                    name="idadde"
                    placeholder="idade"
                    value={this.state.age}
                    onChange={(e) => this.setState({ age: e.target.value })}
                />
            </Modal.Body>
            <Modal.Footer>
                <Button variant="primary" onClick={() => this.updateUser()}>Salvar</Button>
                <Button variant="secondary"
                    onClick={() => this.props.closeModalEdit()}>
                    Cancelar
                </Button>
            </Modal.Footer>
        </Modal>

        )
    }
}

export default ModalEditUser;