package com.example.retodam2rutas.views


import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.example.retodam2rutas.data.database.AppDatabase
import com.example.retodam2rutas.model.UsuarioModel

class LoginViewModel(
    private val appDatabase: AppDatabase
) : ViewModel() {
    private val _usuario = MutableLiveData<UsuarioModel>()
    val usuario: LiveData<UsuarioModel> = _usuario



}