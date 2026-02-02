package com.example.retodam2rutas.components

import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.PaddingValues
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.LocationOn
import androidx.compose.material3.Button
import androidx.compose.material3.CardColors
import androidx.compose.material3.CardDefaults
import androidx.compose.material3.ElevatedCard
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.navigation.NavController
import com.bumptech.glide.integration.compose.ExperimentalGlideComposeApi
import com.bumptech.glide.integration.compose.GlideImage
import com.example.retodam2rutas.data.daos.RutaDao
import com.example.retodam2rutas.model.Ruta
import com.example.retodam2rutas.views.RutaViewModel


//================ Contenido de la ventana home =================
@Composable
fun ContentHomeView(
    innerPadding: PaddingValues,
    navController: NavController,
    rutaViewModel: RutaViewModel) {
    LazyColumn (
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize()
            .background(Color(0x6F98CCEE)),
        verticalArrangement = Arrangement.spacedBy(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        item {
            Text(
                text = "CATALOGO DE RUTAS",
                fontWeight = FontWeight.Bold,
                textAlign = TextAlign.Center,
                modifier = Modifier.fillMaxWidth(),
                color = Color.Black
            )
        }
        items(rutaViewModel.rutas){
            ruta ->
            RutaCard(ruta, navController)
        }
    }
}

//================ Contenido de la ventana detail =================
@Composable
fun ContentDetailView(
    innerPadding: PaddingValues,
    navController: NavController,
    id: Int,
    rutaViewModel: RutaViewModel) {

    rutaViewModel.cargarRuta(id)
    var ruta = rutaViewModel.rutaSeleccionada

    LazyColumn (
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize()
            .background(Color(0x6F98CCEE)),
        verticalArrangement = Arrangement.spacedBy(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        item {
            Text(
                text = "Ruta",
                fontWeight = FontWeight.Bold,
                textAlign = TextAlign.Center,
                modifier = Modifier.fillMaxWidth(),
                color = Color.Black
            )
        }
        item {
            Button(
                onClick = { navController.navigate("Mapa/${ruta?.id}") }
            ) {
                Text("Iniciar ruta")
            }
        }
    }
}

//================ Card de Rutas =================
@OptIn(ExperimentalGlideComposeApi::class)
@Composable
fun RutaCard(ruta: Ruta, navController: NavController) {
    ElevatedCard(
        elevation = CardDefaults.cardElevation(
            defaultElevation = 6.dp
        ),
        modifier = Modifier
            .fillMaxWidth()
            .padding(8.dp)
            .clickable { navController.navigate("Detail/${ruta.id}") },
        colors = CardColors(
            containerColor = Color.Black,
            contentColor = Color.White,
            disabledContainerColor = Color.Gray,
            disabledContentColor = Color.White
        ),
        shape = CardDefaults.shape,
    ) {
        Row(
            modifier = Modifier
                .fillMaxWidth()
                .padding(12.dp),
            verticalAlignment = Alignment.CenterVertically
        ) {
            GlideImage(
                model = Icons.Default.LocationOn,
                contentDescription = "descripcion ruta",
                modifier = Modifier
                    .size(80.dp)
                    .clip(CircleShape)
                    .background(Color.LightGray)
            )

            Spacer(modifier = Modifier.width(16.dp))

            Column(
                modifier = Modifier.weight(1f)
            ) {
                Text(
                    text = ruta.nombre,
                    style = MaterialTheme.typography.titleMedium
                )
                Text(
                    text = "Distancia: ${ruta.distancia}m",
                    style = MaterialTheme.typography.bodyMedium
                )
                Text(
                    text = "Dificultad: ${ruta.nivelEsfuerzo}m",
                    style = MaterialTheme.typography.bodyMedium
                )
                Text(
                    text = "Valoracion: ${ruta.mediaEstrellas}m",
                    style = MaterialTheme.typography.bodyMedium
                )
            }
        }
    }
}