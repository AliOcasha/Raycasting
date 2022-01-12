import pygame as pg
import sys

def checkIntersection(Walls, Ray):
    #Reset List to default Rayfactor
    Ray.f_list = [1000]
    #Check the Intersection Point with every Wall (Analytische Geometrie)
    for Wall in Walls:
        WallZaehler = Ray.direction[0]*(Wall.p1[1]-Ray.Source[1]) + Ray.direction[1]*(Ray.Source[0]-Wall.p1[0])
        WallNenner = (Wall.p2[0]-Wall.p1[0])*Ray.direction[1] - (Wall.p2[1]-Wall.p1[1])*Ray.direction[0]
        try:
             WallIntersectionParameter = WallZaehler/WallNenner
        except ZeroDivisionError:
             WallIntersectionParameter = WallZaehler/0.001
     #If Intersection Point valid for physical Intersection get the Ray Intersection point
        if WallIntersectionParameter > 0 and WallIntersectionParameter <= 1:
            try:
                RayIntersection = (Wall.p1[0]+(Wall.p2[0]-Wall.p1[0])*WallIntersectionParameter-Ray.Source[0])/Ray.direction[0]
            except ZeroDivisionError:
                RayIntersection = (Wall.p1[0]+(Wall.p2[0]-Wall.p1[0])*WallIntersectionParameter-Ray.Source[0])/0.001
            if RayIntersection > 0:
                # Add RayIntersection point to list
                if RayIntersection in Ray.f_list:
                    pass
                else:
                    Ray.f_list.append(RayIntersection)
    # New rayfactor is smallest rayintersectionpoint
    Ray.factor = min(Ray.f_list)