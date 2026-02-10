package com.example.retodam2rutas.views


import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.retodam2rutas.data.database.AppDatabase
import com.example.retodam2rutas.entities.TIPOUSUARIO
import com.example.retodam2rutas.data.service.UsuarioServiceFactory
import com.example.retodam2rutas.data.service.UsuarioServiceImpl
import com.example.retodam2rutas.model.UsuarioModel
import kotlinx.coroutines.flow.SharingStarted
import kotlinx.coroutines.flow.stateIn
import kotlinx.coroutines.launch

class LoginViewModel(
    private val appDatabase: AppDatabase
) : ViewModel() {
    private val _usuario = MutableLiveData<UsuarioModel>()
    val usuario: LiveData<UsuarioModel> = _usuario
    val usuarioService = UsuarioServiceFactory.makeUsuarioService()
    val usuarioServiceImpl = UsuarioServiceImpl(usuarioService, appDatabase.usuarioDao())

    val usuarios = usuarioServiceImpl.usuarios
        .stateIn(
            viewModelScope,
            started = SharingStarted.WhileSubscribed(5000),
            initialValue = emptyList()
        )

    init {
        // Refresh from network
        viewModelScope.launch {
            usuarioServiceImpl.refreshUsers()
        }
    }

    fun getLoginUsuario(email: String, password: String){
        viewModelScope.launch {
            try {
                //Llamada al servicio para obtener el usuario
                val getUser = usuarioService.getLogin(email, password)
                _usuario.value = getUser

            } catch (e: Exception) {
                e.printStackTrace()
            }

        }

    }

    fun setUsuarioInvitado(){
        _usuario.value = UsuarioModel(
            "invitado",
            "invitado",
            -1,
            "invitado",
            "invitado",
            TIPOUSUARIO.usuario.toString(),

        )
    }


}