import React from 'react';
import { Map as LeafletMap, TileLayer, Marker, Popup } from 'react-leaflet';
import "leaflet/dist/leaflet.css";
import styled from 'styled-components';

interface PositionMapProps { 
    position?: L.LatLngLiteral; 
    popUpText?: string; 
    height?: string; 
    width?: string;
    zoom?: number;
    borderRadius?: string;
}

interface StyledLeafletMapProps {
    height: string;
    width: string;
    borderRadius: string;
    zoom: number;
    center: L.LatLngLiteral;
    scrollWheelZoom: boolean;
}

const StyledLeafletMap = styled(LeafletMap)<StyledLeafletMapProps>`
    box-shadow: 0px 0px 9px 0px rgba(0,0,0,0.75);
    height: ${props => props.height};
    width: ${props => props.width};
    min-width: 200px;
    border-radius: ${props => props.borderRadius};
    @media (max-width: 800px) {
        width: 80vw;
    }
`;

function PositionMap(props: PositionMapProps)
{
    const {position = [49.84454, 24.026750] as unknown as L.LatLngLiteral,
        popUpText = "",
        height = "45vh",
        width = "35vw",
        zoom = 10,
        borderRadius = "30px"
    } = props;

    const L = require("leaflet");
    
    React.useEffect(() => {   
        const L = require("leaflet"); 
        delete L.Icon.Default.prototype._getIconUrl;
            
        L.Icon.Default.mergeOptions({
          iconRetinaUrl: require("leaflet/dist/images/marker-icon-2x.png"),
          iconUrl: require("leaflet/dist/images/marker-icon.png"),
          shadowUrl: require("leaflet/dist/images/marker-shadow.png")
        });
      }, []);

    return(
        <StyledLeafletMap
            borderRadius={borderRadius}
            width={width}
            height={height}
            center={position}
            zoom={zoom}
            scrollWheelZoom={false}>
            <TileLayer maxZoom={22}
            attribution='<a href="https://www.maptiler.com/copyright/" target="_blank">&copy; MapTiler</a> <a href="https://www.openstreetmap.org/copyright" target="_blank">&copy; OpenStreetMap contributors</a>'
            url='https://api.maptiler.com/maps/basic/{z}/{x}/{y}.png?key=L7jWH8UlPu3enKseP3Nw'
            />
            <Marker position={position}>
                <Popup>
                    {popUpText}
                </Popup>
            </Marker>
        </StyledLeafletMap>
    );
}
export default PositionMap;
