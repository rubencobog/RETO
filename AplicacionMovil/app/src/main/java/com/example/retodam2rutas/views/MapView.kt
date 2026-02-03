package com.example.retodam2rutas.views

import android.annotation.SuppressLint
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.material3.TopAppBar
import androidx.compose.material3.TopAppBarDefaults.topAppBarColors
import androidx.compose.runtime.Composable
import androidx.compose.runtime.rememberCoroutineScope
import androidx.compose.ui.graphics.Color
import androidx.navigation.NavController
import com.example.retodam2rutas.components.ContentMapView

@OptIn(ExperimentalMaterial3Api::class)
@SuppressLint("UnusedMaterial3ScaffoldPaddingParameter")
@Composable
fun MapView(navController: NavController, id: Int, rutaViewModel: RutaViewModel, mapViewModel: MapViewModel){
    val coroutineScope = rememberCoroutineScope()
    Scaffold(
        topBar = {
            TopAppBar(
                colors = topAppBarColors(
                    containerColor = Color(0xFF041B57),
                    titleContentColor = Color(0xFFC0D1F1),
                ),
                title = {
                    Text("Localizacion GPS // TSEAS")
                }
            )
        },

    ) { innerPadding -> ContentMapView(innerPadding, navController, id, rutaViewModel, mapViewModel) }
}