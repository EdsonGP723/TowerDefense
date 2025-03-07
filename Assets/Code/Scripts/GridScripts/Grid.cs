using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
	
	private int width;
	private int height;
	private float cellSize;
	private Vector3 originPosition;
	private GameObject cell;
	private int[,] gridArray;
	private GameObject[,] arrayTower;
	
	// Constructor que inicializa la cuadrícula y crea todas las celdas
	public Grid(int width, int height, float cellSize ,GameObject cell, Vector3 originPosition){
		this.width = width;
		this.height = height;
		this.cell = cell;
		this.cellSize = cellSize;
		this.originPosition = originPosition;
		
		gridArray = new int[width,height];
		arrayTower = new GameObject[width,height];
		
		// Crea las celdas de la cuadrícula en el mundo
		for(int x=0; x<gridArray.GetLength(0); x++){
			for(int y=0; y<gridArray.GetLength(1); y++){
				// Instancia cada celda y la coloca en su posición correcta
				// Añade offset de medio tamaño para centrar la celda en sus coordenadas
				arrayTower[x,y] = GameObject.Instantiate(cell,GetWorldPosition(x,y)+ new Vector3(cellSize,cellSize)*.5f,Quaternion.identity);
			}	
		}
	}
	
	// Convierte coordenadas de la cuadrícula a posición en el mundo
	private Vector3 GetWorldPosition(int x, int y){
		return new Vector3(x,y)* cellSize + originPosition;
	}
	
	// Convierte posición del mundo a coordenadas de la cuadrícula
	private void GetXY(Vector3 worldPosition, out int x, out int y){
		x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
		y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
	}
	
	// Coloca una torre en coordenadas específicas de la cuadrícula
	private void SetLocationTower(int x, int y, GameObject tower){
		if (x >= 0 && y >= 0 && x < width && y < height){ 
			arrayTower[x,y] = GameObject.Instantiate(tower,GetWorldPosition(x,y)+ new Vector3(cellSize,cellSize)*.5f,Quaternion.identity);
		}
	}
	
	// Método público para colocar torres usando posiciones del mundo
	public void SetTower(Vector3 worldPosition, GameObject tower){
		int x, y;
		GetXY(worldPosition, out x, out y);
		SetLocationTower(x,y,tower);
	}
}
