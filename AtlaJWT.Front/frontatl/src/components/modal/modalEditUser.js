import React from "react";
import { Modal, Button } from 'react-bootstrap';
import { Input, Label } from "reactstrap";
import req from "../../services/req";
import { showModalSwal } from '../../shared/util'

class ModalEditUser extends React.Component {
    state = {
        userName: "",
        password: "",
        age: 0,
        showModal: false
    }

    updateUser = () => {
        const { age, userName, password } = this.state;
        const obj = {
            "id": this.props.user.id,
            "idUserInfo": this.props.user.idUserInfo,
            "name": userName,
            "age": age
        }

        req.updateUserRegistered(obj).then(x => {
          const { data, status } = x;

          if(status === 200)
          {
                this.props.closeModalEdit();
                showModalSwal("Usuário editado com sucesso", "success");
          }
          
            console.log(x.data, 'X');
        }).catch(x => {

        })
    }

    componentDidMount = () => {
        if (this.props.user !== undefined) {
            this.setState({
                showModal: this.props.showModalEdit,
                userName: this.props.user.name,
                age: this.props.user.age
            })
        }
    }

    render() {
        console.log(this.props.user, 'USER NO MODAL EDIT');
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