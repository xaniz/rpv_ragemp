-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 31, 2023 at 06:17 PM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 7.3.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `s40595_rpvdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_warns`
--

CREATE TABLE `admin_warns` (
  `id` int(11) DEFAULT 0,
  `user_id` int(11) DEFAULT 0,
  `character_name` tinytext DEFAULT NULL,
  `admin_user_id` int(11) DEFAULT 0,
  `admin_name` tinytext DEFAULT NULL,
  `reason` text DEFAULT NULL,
  `date` datetime DEFAULT current_timestamp(),
  `isactive` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `business`
--

CREATE TABLE `business` (
  `id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL DEFAULT '',
  `owner_name` varchar(32) NOT NULL DEFAULT 'Ninguem',
  `owner_id` int(11) NOT NULL DEFAULT -1,
  `type` int(11) NOT NULL DEFAULT 0,
  `price` int(11) NOT NULL DEFAULT 9999999,
  `pos_x` varchar(32) NOT NULL DEFAULT '0',
  `pos_y` varchar(32) NOT NULL DEFAULT '0',
  `pos_z` varchar(32) NOT NULL DEFAULT '0.00000',
  `chemical_xyz` varchar(50) NOT NULL DEFAULT '0,0,0',
  `chemical_price` varchar(200) NOT NULL DEFAULT '0,0,0',
  `lock_status` int(11) NOT NULL DEFAULT 0,
  `safe` int(11) NOT NULL DEFAULT 0,
  `inventory` int(11) NOT NULL DEFAULT 0,
  `inventory_capacity` int(11) NOT NULL DEFAULT 0,
  `business_store_buy_x` varchar(32) NOT NULL DEFAULT '0',
  `business_store_buy_y` varchar(32) NOT NULL DEFAULT '0',
  `business_store_buy_z` varchar(32) NOT NULL DEFAULT '0',
  `business_store_item_price_0` int(11) NOT NULL DEFAULT 0,
  `business_store_item_name_0` varchar(32) NOT NULL DEFAULT '0',
  `business_store_item_price_1` int(11) NOT NULL DEFAULT 0,
  `business_store_item_name_1` varchar(32) NOT NULL DEFAULT '0',
  `business_store_item_price_2` int(11) NOT NULL DEFAULT 0,
  `business_store_item_name_2` varchar(32) NOT NULL DEFAULT '0',
  `business_store_item_price_3` int(11) NOT NULL DEFAULT 0,
  `business_store_item_name_3` varchar(32) NOT NULL DEFAULT '0',
  `business_store_item_price_4` int(11) NOT NULL DEFAULT 0,
  `business_store_item_name_4` varchar(32) NOT NULL DEFAULT '0',
  `business_store_item_price_5` int(11) NOT NULL DEFAULT 0,
  `business_store_item_name_5` varchar(32) NOT NULL DEFAULT '0',
  `business_store_item_price_6` int(11) NOT NULL DEFAULT 0,
  `business_store_item_name_6` varchar(32) NOT NULL DEFAULT '0',
  `stock_manage_x` varchar(255) DEFAULT '0.0000',
  `stock_manage_y` varchar(255) DEFAULT '0.0000',
  `stock_manage_z` varchar(255) DEFAULT '0.0000',
  `gas_pump_0_x` varchar(255) DEFAULT '0.0000',
  `gas_pump_0_y` varchar(255) DEFAULT '0.0000',
  `gas_pump_0_z` varchar(255) DEFAULT '0.0000',
  `gas_pump_0_capacity` varchar(255) DEFAULT '0.0000',
  `gas_pump_0_gas` varchar(255) DEFAULT '0.0000',
  `gas_pump_1_x` varchar(255) DEFAULT '0.0000',
  `gas_pump_1_y` varchar(255) DEFAULT '0.0000',
  `gas_pump_1_z` varchar(255) DEFAULT '0.0000',
  `gas_pump_1_capacity` varchar(255) DEFAULT '0.0000',
  `gas_pump_1_gas` varchar(255) DEFAULT '0.0000',
  `gas_pump_2_x` varchar(255) DEFAULT '0.0000',
  `gas_pump_2_y` varchar(255) DEFAULT '0.0000',
  `gas_pump_2_z` varchar(255) DEFAULT '0.0000',
  `gas_pump_2_capacity` varchar(255) DEFAULT '0.0000',
  `gas_pump_2_gas` varchar(255) DEFAULT '0.0000',
  `gas_pump_3_x` varchar(255) DEFAULT '0.0000',
  `gas_pump_3_y` varchar(255) DEFAULT '0.0000',
  `gas_pump_3_z` varchar(255) DEFAULT '0.0000',
  `gas_pump_3_capacity` varchar(255) DEFAULT '0.0000',
  `gas_pump_3_gas` varchar(255) DEFAULT '0.0000',
  `gas_pump_4_x` varchar(255) DEFAULT '0.0000',
  `gas_pump_4_y` varchar(255) DEFAULT '0.0000',
  `gas_pump_4_z` varchar(255) DEFAULT '0.0000',
  `gas_pump_4_capacity` varchar(255) DEFAULT '0.0000',
  `gas_pump_4_gas` varchar(255) DEFAULT '0.0000',
  `gas_pump_5_x` varchar(255) DEFAULT '0.0000',
  `gas_pump_5_y` varchar(255) DEFAULT '0.0000',
  `gas_pump_5_z` varchar(255) DEFAULT '0.0000',
  `gas_pump_5_capacity` varchar(255) DEFAULT '0.0000',
  `gas_pump_5_gas` varchar(255) DEFAULT '0.0000',
  `gas_pump_6_x` varchar(255) DEFAULT '0.0000',
  `gas_pump_6_y` varchar(255) DEFAULT '0.0000',
  `gas_pump_6_z` varchar(255) DEFAULT '0.0000',
  `gas_pump_6_capacity` varchar(255) DEFAULT '0.0000',
  `gas_pump_6_gas` varchar(255) DEFAULT '0.0000',
  `gas_pump_7_x` varchar(255) DEFAULT '0.0000',
  `gas_pump_7_y` varchar(255) DEFAULT '0.0000',
  `gas_pump_7_z` varchar(255) DEFAULT '0.0000',
  `gas_pump_7_capacity` varchar(255) DEFAULT '0.0000',
  `gas_pump_7_gas` varchar(255) DEFAULT '0.0000',
  `gas_pump_8_x` varchar(255) DEFAULT '0.0000',
  `gas_pump_8_y` varchar(255) DEFAULT '0.0000',
  `gas_pump_8_z` varchar(255) DEFAULT '0.0000',
  `gas_pump_8_capacity` varchar(255) DEFAULT '0.0000',
  `gas_pump_8_gas` varchar(255) DEFAULT '0.0000',
  `gas_pump_9_x` varchar(255) DEFAULT '0.0000',
  `gas_pump_9_y` varchar(255) DEFAULT '0.0000',
  `gas_pump_9_z` varchar(255) DEFAULT '0.0000',
  `gas_pump_9_capacity` varchar(255) DEFAULT '0.0000',
  `gas_pump_9_gas` varchar(255) DEFAULT '0.0000',
  `gas_price` int(11) DEFAULT 20,
  `business_restock_x` varchar(255) DEFAULT '0.0000',
  `business_restock_y` varchar(255) DEFAULT '0.0000',
  `business_restock_z` varchar(255) DEFAULT '0.0000',
  `weapon_price` varchar(50) DEFAULT NULL,
  `ammunation_x` varchar(255) DEFAULT '0.0000',
  `ammunation_y` varchar(255) DEFAULT '0.0000',
  `ammunation_z` varchar(255) DEFAULT '0.0000',
  `clothes_store_position` varchar(128) DEFAULT '0|0|0|0',
  `barber_store_position` varchar(128) DEFAULT '0|0|0|0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `business`
--

INSERT INTO `business` (`id`, `name`, `owner_name`, `owner_id`, `type`, `price`, `pos_x`, `pos_y`, `pos_z`, `chemical_xyz`, `chemical_price`, `lock_status`, `safe`, `inventory`, `inventory_capacity`, `business_store_buy_x`, `business_store_buy_y`, `business_store_buy_z`, `business_store_item_price_0`, `business_store_item_name_0`, `business_store_item_price_1`, `business_store_item_name_1`, `business_store_item_price_2`, `business_store_item_name_2`, `business_store_item_price_3`, `business_store_item_name_3`, `business_store_item_price_4`, `business_store_item_name_4`, `business_store_item_price_5`, `business_store_item_name_5`, `business_store_item_price_6`, `business_store_item_name_6`, `stock_manage_x`, `stock_manage_y`, `stock_manage_z`, `gas_pump_0_x`, `gas_pump_0_y`, `gas_pump_0_z`, `gas_pump_0_capacity`, `gas_pump_0_gas`, `gas_pump_1_x`, `gas_pump_1_y`, `gas_pump_1_z`, `gas_pump_1_capacity`, `gas_pump_1_gas`, `gas_pump_2_x`, `gas_pump_2_y`, `gas_pump_2_z`, `gas_pump_2_capacity`, `gas_pump_2_gas`, `gas_pump_3_x`, `gas_pump_3_y`, `gas_pump_3_z`, `gas_pump_3_capacity`, `gas_pump_3_gas`, `gas_pump_4_x`, `gas_pump_4_y`, `gas_pump_4_z`, `gas_pump_4_capacity`, `gas_pump_4_gas`, `gas_pump_5_x`, `gas_pump_5_y`, `gas_pump_5_z`, `gas_pump_5_capacity`, `gas_pump_5_gas`, `gas_pump_6_x`, `gas_pump_6_y`, `gas_pump_6_z`, `gas_pump_6_capacity`, `gas_pump_6_gas`, `gas_pump_7_x`, `gas_pump_7_y`, `gas_pump_7_z`, `gas_pump_7_capacity`, `gas_pump_7_gas`, `gas_pump_8_x`, `gas_pump_8_y`, `gas_pump_8_z`, `gas_pump_8_capacity`, `gas_pump_8_gas`, `gas_pump_9_x`, `gas_pump_9_y`, `gas_pump_9_z`, `gas_pump_9_capacity`, `gas_pump_9_gas`, `gas_price`, `business_restock_x`, `business_restock_y`, `business_restock_z`, `weapon_price`, `ammunation_x`, `ammunation_y`, `ammunation_z`, `clothes_store_position`, `barber_store_position`) VALUES
(0, '', 'niko', -1, 0, 9999999, '0.00000', '0.00000', '0.00000', '0,0,0', '00000000000', 0, 0, 50, 100, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '0', '0', '0', '0', '0', '0', '0', '0|0|0|0', '0|0|0|0'),
(1, 'Clothes Shop', 'niko', -1, 1, 9999999, '-702', '-152', '37', '0,0,0', '00000000000', 0, 0, 0, 0, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '-723.5566', '-160.8705', '36.93811', '0', '0', '0', '0', '-711.1914|-155.2118|37.41513|123.1112', '0|0|0|0'),
(2, 'Clothes Shop', 'niko', -1, 1, 9999999, '-1182', '-765', '17', '0,0,0', '00000000000', 0, 0, 50, 100, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '-1207.19', '-783.6997', '17.05799', '0', '0', '0', '0', '-1196.838|-774.1051|17.32328|127.5491', '0|0|0|0'),
(3, 'Clothes Shop', 'niko', -1, 1, 9999999, '-821', '-1068.453', '11.33416', '0,0,0', '00000000000', 0, 0, 0, 0, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '-815.0988', '-1085.357', '10.9902', '0', '0', '0', '0', '-819.3118|-1074.762|11.32811|203.5067', '0|0|0|0'),
(4, 'BarberShop', 'niko', -1, 10, 750000, '-284', '6231.618', '31.489096', '0,0,0', '00000000000', 0, 0, 100, 100, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '-288.726', '6237.9277', '31.348288', '0', '0', '0', '0', '0|0|0|0', '-278.71152|6228.72|31.695515|-143.1359'),
(5, 'Gun Shop', 'niko', -1, 3, 4200000, '-326', '6074.0293', '31.240667', '0,0,0', '00000000000', 0, 12000, 100, 100, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '-339.31155', '6073.9346', '31.315525', '300,700,500,800,3800,5700,7100', '-330.59573', '6083.971', '31.454786', '0|0|0|0', '0|0|0|0'),
(6, 'Clothes Shop', 'niko', -1, 1, 9999999, '118', '-232.5694', '54.55782', '0,0,0', '00000000000', 0, 0, 0, 0, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '129.5079', '-201.2187', '54.51412', '0', '0', '0', '0', '125.2743|-217.1786|54.55782|337.019', '0|0|0|0'),
(8, 'Clothes Shop', 'niko', -1, 1, 9999999, '1687', '4818.776', '41.990604', '0,0,0', '00000000000', 0, 0, 100, 100, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '1678.8413', '4820.738', '42.006958', '0', '0', '0', '0', '1695.415|4828.8154|42.06312|96.57243', '0|0|0|0'),
(11, 'Gun Shop', 'niko', -1, 3, 1500000, '15', '-1115.1224', '29.791185', '0,0,0', '00000000000', 0, 0, 100, 100, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '15.371599', '-1126.1107', '28.721123', '300,700,500,800,3800,5700,7100', '21.90537', '-1106.7544', '29.797028', '0|0|0|0', '0|0|0|0'),
(12, 'Gun Shop', 'niko', -1, 3, 1500000, '-1315.5477', '-392.26523', '36.575016', '0,0,0', '00000000000', 0, 0, 100, 100, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '-1320.5104', '-389.65164', '36.463898', '300,700,500,800,3800,5700,7100', '-1305.358', '-394.3824', '36.6958', '0|0|0|0', '0|0|0|0'),
(14, 'Tattoo Salon', 'niko', -1, 12, 9999999, '1859.2158', '3750.2434', '33.004444', '0,0,0', '00000000000', 0, 0, 10000, 10000, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '1857.7074', '3770.8423', '32.772964', '0', '0', '0', '0', '0|0|0|0', '1864.3638|3747.7317|33.031883|36.727005'),
(15, 'BarberShop', 'niko', -1, 10, 9999999, '-808.9664', '-181.9135', '37.56892', '0,0,0', '00000000000', 0, 0, 50, 100, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '-807.4999', '-189.596', '37.38385', '0', '0', '0', '0', '0|0|0|0', '-814.5709|-184.036|37.56892|111.9992'),
(16, 'Clothes Shop', 'niko', -1, 1, 1300000, '0.42701998', '6518.3574', '31.49479', '0,0,0', '00000000000', 0, 0, 0, 0, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '0.43577316', '6503.5474', '31.472486', '0', '0', '0', '0', '11.646373|6513.5337|31.877853|41.44818', '0|0|0|0'),
(18, 'Clothes Shop', 'niko', -1, 1, 9999999, '1198.0905', '2713.9795', '38.222652', '0,0,0', '00000000000', 0, 0, 1000, 1000, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 3, '0', '0', '0', '0', '0', '0', '0', '1198.541|2707.534|38.22265|-3.24826', '0|0|0|0'),
(20, 'Autosalon', 'niko', -1, 4, 9999999, '-40', '-1099', '26', '0,0,0', '00000000000', 0, 0, 0, 0, '0', '0', '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', 0, '0', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', '0.0000', 20, '-35', '-1102', '26', '0', '0.0000', '0.0000', '0.0000', '0|0|0|0', '0|0|0|0');

-- --------------------------------------------------------

--
-- Table structure for table `business_type_dealership_points`
--

CREATE TABLE `business_type_dealership_points` (
  `id` int(11) NOT NULL,
  `buy` varchar(128) DEFAULT '0|0|0',
  `preview` varchar(128) DEFAULT '0|0|0',
  `vehicle` varchar(128) DEFAULT '0|0|0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `business_type_dealership_points`
--

INSERT INTO `business_type_dealership_points` (`id`, `buy`, `preview`, `vehicle`) VALUES
(0, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(1, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(2, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(3, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(4, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(5, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(6, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(7, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(8, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(9, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(10, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(11, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(12, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(13, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(14, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(15, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(16, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(17, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(18, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(19, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(20, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(21, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(22, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(23, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(24, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(25, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(26, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(27, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(28, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(29, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(30, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(31, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(32, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(33, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(34, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(35, '-32.41|-1111.41|26.42|0', '526.85|-3233.31|46.31|177.1', '-11.48|-1080.72|26.67|130.19'),
(36, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(37, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(38, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(39, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(40, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(41, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(42, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(43, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(44, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(45, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(46, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(47, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(48, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(49, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(50, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(51, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(52, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(53, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(54, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(55, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(56, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(57, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(58, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(59, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(60, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(61, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(62, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(63, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(64, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(65, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(66, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(67, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(68, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(69, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(70, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(71, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(72, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(73, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(74, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(75, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(76, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(77, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(78, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(79, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(80, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(81, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(82, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(83, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(84, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(85, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(86, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(87, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(88, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(89, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(90, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(91, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(92, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(93, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(94, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(95, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(96, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(97, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(98, '0|0|0|0', '0|0|0|0', '0|0|0|0'),
(99, '0|0|0|0', '0|0|0|0', '0|0|0|0');

-- --------------------------------------------------------

--
-- Table structure for table `business_vehicles`
--

CREATE TABLE `business_vehicles` (
  `id` int(11) NOT NULL,
  `business_id` int(11) DEFAULT -1,
  `vehicle_model` varchar(255) DEFAULT NULL,
  `vehicle_price` int(11) DEFAULT 0,
  `vehicle_stock` int(11) DEFAULT 0,
  `vehicle_status` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `challange`
--

CREATE TABLE `challange` (
  `name` varchar(50) DEFAULT NULL,
  `time` decimal(5,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `challange`
--

INSERT INTO `challange` (`name`, `time`) VALUES
('Xanis Xan', '76.22');

-- --------------------------------------------------------

--
-- Table structure for table `characters`
--

CREATE TABLE `characters` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL DEFAULT '',
  `userid` int(11) NOT NULL,
  `status` int(11) DEFAULT 0,
  `money` int(11) NOT NULL DEFAULT 0,
  `char` varchar(2024) NOT NULL DEFAULT '',
  `bank` int(11) NOT NULL DEFAULT 0,
  `salary` int(11) NOT NULL DEFAULT 0,
  `age` tinyint(4) DEFAULT 17,
  `level` int(11) NOT NULL DEFAULT 1,
  `exp` int(11) NOT NULL DEFAULT 0,
  `leader` int(11) NOT NULL DEFAULT 0,
  `group` int(11) NOT NULL DEFAULT 0,
  `canteleport` tinyint(1) NOT NULL DEFAULT 0,
  `group_rank` int(11) NOT NULL DEFAULT 0,
  `job` int(11) NOT NULL DEFAULT 0,
  `wanted` int(11) NOT NULL DEFAULT 0,
  `last_crime` varchar(32) NOT NULL DEFAULT 'null',
  `prison` int(11) NOT NULL DEFAULT 0,
  `prison_cell` int(11) NOT NULL DEFAULT 0,
  `prison_time` int(11) NOT NULL DEFAULT 0,
  `ooc_prison_time` int(11) NOT NULL DEFAULT 0,
  `ooc_warning` int(11) NOT NULL DEFAULT 0,
  `exp_time` int(11) NOT NULL DEFAULT 0,
  `char_position_x` varchar(255) NOT NULL DEFAULT '-1033.615',
  `char_position_y` varchar(255) NOT NULL DEFAULT '-2730.645',
  `char_position_z` varchar(255) NOT NULL DEFAULT '13.75664',
  `char_rotation_z` varchar(255) NOT NULL DEFAULT '-31.40833',
  `char_torso` int(11) NOT NULL DEFAULT 0,
  `char_undershirt` int(11) NOT NULL DEFAULT 0,
  `char_undershirt_texture` int(11) NOT NULL DEFAULT 0,
  `char_leg` int(11) NOT NULL DEFAULT 0,
  `char_leg_texture` int(11) NOT NULL DEFAULT 0,
  `char_feet` int(11) NOT NULL DEFAULT 0,
  `char_feet_texture` int(11) NOT NULL DEFAULT 0,
  `char_shirt` int(11) NOT NULL DEFAULT 0,
  `char_shirt_texture` int(11) NOT NULL DEFAULT 0,
  `char_mask` int(11) NOT NULL DEFAULT 0,
  `char_mask_texture` int(11) NOT NULL DEFAULT 0,
  `char_armor` int(11) NOT NULL DEFAULT 0,
  `char_armor_texture` int(11) NOT NULL DEFAULT 0,
  `char_outfit` int(11) NOT NULL DEFAULT -1,
  `char_outfit_duty` int(11) NOT NULL DEFAULT -1,
  `character_hats` int(11) DEFAULT 0,
  `character_hats_texture` int(11) DEFAULT 0,
  `character_glasses` int(11) DEFAULT 0,
  `character_glasses_texture` int(11) DEFAULT 0,
  `character_ears` int(11) DEFAULT 0,
  `character_ears_texture` int(11) DEFAULT 0,
  `character_watches` int(11) DEFAULT 0,
  `character_watches_texture` int(11) DEFAULT 0,
  `character_bracelets` int(11) DEFAULT 0,
  `character_bracelets_texutre` int(11) DEFAULT 0,
  `character_accessories` int(11) DEFAULT 0,
  `character_accessories_texture` int(11) DEFAULT 0,
  `helmet` int(11) DEFAULT 0,
  `helmet_texture` int(11) DEFAULT 0,
  `business_key` int(11) NOT NULL DEFAULT -1,
  `hunger` varchar(32) NOT NULL DEFAULT '100',
  `thirsty` varchar(32) NOT NULL DEFAULT '100',
  `hospital` int(11) NOT NULL DEFAULT 0,
  `death` int(11) NOT NULL DEFAULT 0,
  `death_seconds` int(11) NOT NULL DEFAULT 0,
  `char_dimension` int(11) NOT NULL DEFAULT 0,
  `connected_seconds` int(11) NOT NULL DEFAULT 0,
  `inside_house` varchar(255) DEFAULT 'null',
  `ammo_handguns` int(11) DEFAULT 0,
  `ammo_assaultrifles` int(11) DEFAULT 0,
  `ammo_sniperrifles` int(11) DEFAULT 0,
  `ammo_shotguns` int(11) DEFAULT 0,
  `ammo_machineguns` int(11) DEFAULT 0,
  `peixe_0` int(11) DEFAULT -1,
  `peixe_1` int(11) DEFAULT -1,
  `peixe_2` int(11) DEFAULT -1,
  `peixe_3` int(11) DEFAULT -1,
  `peixe_4` int(11) DEFAULT -1,
  `peixe_5` int(11) DEFAULT -1,
  `peixe_6` int(11) DEFAULT -1,
  `peixe_7` int(11) DEFAULT -1,
  `peixe_8` int(11) DEFAULT -1,
  `peixe_9` int(11) DEFAULT -1,
  `primary_weapon` varchar(32) DEFAULT '0',
  `primary_ammunation` int(11) DEFAULT 0,
  `secundary_weapon` varchar(32) DEFAULT '0',
  `secundary_ammunation` int(11) DEFAULT 0,
  `pistol_weapon` varchar(50) DEFAULT '0',
  `pistol_ammunation` int(11) DEFAULT 0,
  `tazer_weapon` varchar(50) DEFAULT '0',
  `melee` varchar(32) DEFAULT '0',
  `character_torso_texture` int(11) DEFAULT 0,
  `backpack` int(11) DEFAULT 0,
  `character_vip` int(11) DEFAULT 0,
  `character_donator` int(11) DEFAULT 0,
  `character_credits` int(11) DEFAULT 0,
  `health` int(11) DEFAULT 100,
  `colete` int(11) DEFAULT 0,
  `character_vip_date` datetime(6) DEFAULT NULL,
  `character_vip_expire` datetime(6) DEFAULT NULL,
  `LastLogin` datetime(6) DEFAULT NULL,
  `CreateCharacter` datetime(6) DEFAULT NULL,
  `character_vehicle_slots` int(11) DEFAULT 0,
  `character_house_slots` int(11) DEFAULT 0,
  `character_cat` int(11) DEFAULT 0,
  `character_cellphone` int(11) DEFAULT 0,
  `car_lic` int(11) DEFAULT 0,
  `truck_lic` int(11) DEFAULT 0,
  `fly_lic` int(11) DEFAULT 0,
  `fish_lic` int(11) DEFAULT 0,
  `moto_lic` int(11) DEFAULT 0,
  `taxi_lic` int(11) DEFAULT 0,
  `gun_lic` int(11) DEFAULT 0,
  `character_rppoints` int(11) DEFAULT 0,
  `shortcut_0` varchar(255) DEFAULT '||0',
  `shortcut_1` varchar(255) DEFAULT '||0',
  `shortcut_2` varchar(255) DEFAULT '||0',
  `shortcut_3` varchar(255) DEFAULT '||0',
  `shortcut_4` varchar(255) DEFAULT '||0',
  `shortcut_5` varchar(255) DEFAULT '||0',
  `shortcut_6` varchar(255) DEFAULT '||0',
  `shortcut_7` varchar(255) DEFAULT '||0',
  `shortcut_8` varchar(255) DEFAULT '||0',
  `shortcut_9` varchar(255) DEFAULT '||0',
  `salaryvalue` int(11) DEFAULT 0,
  `character_WalkStyle` varchar(50) DEFAULT '',
  `radio_freq` int(11) DEFAULT 0,
  `pizzajob` int(11) DEFAULT 0,
  `adminLevel` int(11) DEFAULT 0,
  `apin` int(11) DEFAULT 0,
  `loggedin` int(11) DEFAULT 0,
  `zadatak` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `companies`
--

CREATE TABLE `companies` (
  `id` int(11) NOT NULL DEFAULT -1,
  `name` varchar(50) NOT NULL DEFAULT 'nema',
  `owner` int(11) NOT NULL DEFAULT -1,
  `owner_name` varchar(50) DEFAULT 'niko',
  `money` int(11) NOT NULL DEFAULT 0,
  `lock_status` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `companies`
--

INSERT INTO `companies` (`id`, `name`, `owner`, `owner_name`, `money`, `lock_status`) VALUES
(0, 'Weazel News', 17, 'Hadehd', 10000, 0),
(1, 'LS Transit', 24, 'Test Tester', 0, 0),
(2, 'PLS', -1, 'niko', 0, 0),
(3, 'Fleeca', 27, 'Hadehd ', 50, 0),
(4, 'SA Petroleum', -1, 'niko', 81, 0),
(5, 'LS Rentabile', -1, 'niko', 0, 0),
(6, 'InstantDrink', -1, 'niko', 0, 0),
(7, '24/7', -1, 'niko', 425, 0),
(8, 'SA PS', -1, 'niko', 150, 0),
(9, 'Ammunation', -1, 'niko', 70, 0);

-- --------------------------------------------------------

--
-- Table structure for table `contacts`
--

CREATE TABLE `contacts` (
  `id` int(11) NOT NULL,
  `owner` int(11) NOT NULL DEFAULT -1,
  `name` varchar(64) DEFAULT 'indefinido',
  `number` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `crime_report`
--

CREATE TABLE `crime_report` (
  `id` int(11) NOT NULL,
  `office` varchar(34) NOT NULL DEFAULT 'Desconhecido',
  `suspect` varchar(34) NOT NULL DEFAULT 'Desconhecido',
  `price` int(11) NOT NULL DEFAULT 0,
  `stars` int(11) NOT NULL DEFAULT 0,
  `datetime` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `custom_farm`
--

CREATE TABLE `custom_farm` (
  `id` int(11) NOT NULL,
  `owner_id` int(11) NOT NULL DEFAULT 0,
  `Land_Pos` varchar(50) NOT NULL DEFAULT '0,0,0',
  `Land_Range` varchar(50) NOT NULL DEFAULT '0',
  `Plants` varchar(1024) NOT NULL DEFAULT '0',
  `Plants_Pos` varchar(512) NOT NULL DEFAULT '0,0,0',
  `Plants_Time` varchar(512) NOT NULL DEFAULT '0',
  `Plants_Lvl` varchar(512) NOT NULL DEFAULT '0',
  `Khak_Health` int(11) NOT NULL DEFAULT 1000,
  `Partner` varchar(512) NOT NULL DEFAULT '0',
  `price` int(11) NOT NULL DEFAULT 9999999,
  `modelid` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `entraces`
--

CREATE TABLE `entraces` (
  `id` int(11) NOT NULL,
  `name` varchar(32) DEFAULT 'Private Business',
  `description` varchar(128) DEFAULT '32',
  `price` int(11) DEFAULT 20000000,
  `sellproperty` int(11) DEFAULT 1,
  `sellpoint` char(50) DEFAULT '0',
  `blip_pos` char(50) DEFAULT '0,0,0',
  `manage` char(50) DEFAULT '0,0,0',
  `products` mediumtext DEFAULT NULL,
  `blip_id` int(11) DEFAULT -1,
  `blip_color` int(11) DEFAULT 0,
  `owner_id` int(11) DEFAULT -1,
  `lock` tinyint(4) DEFAULT 1,
  `exterior_x` float(32,0) DEFAULT 0,
  `exterior_y` float(32,0) DEFAULT 0,
  `exterior_z` float(32,0) DEFAULT 0,
  `exterior_a` float(32,0) DEFAULT 0,
  `interior_x` float(32,0) DEFAULT 0,
  `interior_y` float(32,0) DEFAULT 0,
  `interior_z` float(32,0) DEFAULT 0,
  `interior_a` float(32,0) DEFAULT 0,
  `interior_dimension` int(11) DEFAULT 0,
  `exterior_dimension` int(11) DEFAULT 0,
  `safemoney` int(11) DEFAULT 0,
  `isforsell` int(11) DEFAULT 0,
  `business_type` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `entraces`
--

INSERT INTO `entraces` (`id`, `name`, `description`, `price`, `sellproperty`, `sellpoint`, `blip_pos`, `manage`, `products`, `blip_id`, `blip_color`, `owner_id`, `lock`, `exterior_x`, `exterior_y`, `exterior_z`, `exterior_a`, `interior_x`, `interior_y`, `interior_z`, `interior_a`, `interior_dimension`, `exterior_dimension`, `safemoney`, `isforsell`, `business_type`) VALUES
(0, '', '', 20000000, 1, '0', '0,0,0', '0,0,0', '[]', -1, 0, -1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(1, '', '', 20000000, 1, '0', '0,0,0', '0,0,0', '[]', -1, 0, -1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `faction`
--

CREATE TABLE `faction` (
  `id` int(11) NOT NULL DEFAULT 0,
  `type` int(11) DEFAULT 0,
  `name` varchar(255) DEFAULT 'indefinido',
  `abbrev` varchar(255) DEFAULT 'indefinido',
  `leader` int(11) DEFAULT -1,
  `motd` varchar(255) DEFAULT 'indefinido',
  `color` varchar(255) DEFAULT 'indefinido',
  `stock` int(11) DEFAULT 0,
  `logo` varchar(255) DEFAULT 'https://i.imgur.com/BRSSf6F.png',
  `verify` tinyint(4) DEFAULT 0,
  `description` varchar(255) DEFAULT 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o',
  `armory_x` float(255,0) DEFAULT 0,
  `armory_y` float(255,0) DEFAULT 0,
  `armory_z` float(255,0) DEFAULT 0,
  `armory_gun_0` varchar(32) DEFAULT '0',
  `armory_stock_0` int(11) DEFAULT 0,
  `armory_price_0` int(11) DEFAULT 0,
  `armory_gun_1` varchar(32) DEFAULT '0',
  `armory_stock_1` int(11) DEFAULT 0,
  `armory_price_1` int(11) DEFAULT 0,
  `armory_gun_2` varchar(32) DEFAULT '0',
  `armory_stock_2` int(11) DEFAULT 0,
  `armory_price_2` int(11) DEFAULT 0,
  `armory_gun_3` varchar(32) DEFAULT '0',
  `armory_stock_3` int(11) DEFAULT 0,
  `armory_price_3` int(11) DEFAULT 0,
  `armory_gun_4` varchar(32) DEFAULT '0',
  `armory_stock_4` int(11) DEFAULT 0,
  `armory_price_4` int(11) DEFAULT 0,
  `armory_gun_5` varchar(32) DEFAULT '0',
  `armory_stock_5` int(11) DEFAULT 0,
  `armory_price_5` int(11) DEFAULT 0,
  `armory_gun_6` varchar(32) DEFAULT '0',
  `armory_stock_6` int(11) DEFAULT 0,
  `armory_price_6` int(11) DEFAULT 0,
  `armory_gun_7` varchar(32) DEFAULT '0',
  `armory_stock_7` int(11) DEFAULT 0,
  `armory_price_7` int(11) DEFAULT 0,
  `armory_gun_8` varchar(32) DEFAULT '0',
  `armory_stock_8` int(11) DEFAULT 0,
  `armory_price_8` int(11) DEFAULT 0,
  `armory_gun_9` varchar(32) DEFAULT '0',
  `armory_stock_9` int(11) DEFAULT 0,
  `armory_price_9` int(11) DEFAULT 0,
  `armory_gun_10` varchar(32) DEFAULT '0',
  `armory_stock_10` int(11) DEFAULT 0,
  `armory_price_10` int(11) DEFAULT 0,
  `armory_gun_11` varchar(32) DEFAULT '0',
  `armory_stock_11` int(11) DEFAULT 0,
  `armory_price_11` int(11) DEFAULT 0,
  `armory_gun_12` varchar(32) DEFAULT '0',
  `armory_stock_12` int(11) DEFAULT 0,
  `armory_price_12` int(11) DEFAULT 0,
  `armory_gun_13` varchar(32) DEFAULT '0',
  `armory_stock_13` int(11) DEFAULT 0,
  `armory_price_13` int(11) DEFAULT 0,
  `armory_gun_14` varchar(32) DEFAULT '0',
  `armory_stock_14` int(11) DEFAULT 0,
  `armory_price_14` int(11) DEFAULT 0,
  `armory_gun_15` varchar(32) DEFAULT '0',
  `armory_stock_15` int(11) DEFAULT 0,
  `armory_price_15` int(11) DEFAULT 0,
  `armory_gun_16` varchar(32) DEFAULT '0',
  `armory_stock_16` int(11) DEFAULT 0,
  `armory_price_16` int(11) DEFAULT 0,
  `armory_gun_17` varchar(32) DEFAULT '0',
  `armory_stock_17` int(11) DEFAULT 0,
  `armory_price_17` int(11) DEFAULT 0,
  `armory_gun_18` varchar(32) DEFAULT '0',
  `armory_stock_18` int(11) DEFAULT 0,
  `armory_price_18` int(11) DEFAULT 0,
  `armory_gun_19` varchar(32) DEFAULT '0',
  `armory_stock_19` int(11) DEFAULT 0,
  `armory_price_19` int(11) DEFAULT 0,
  `zone_color` int(11) DEFAULT 0,
  `level` int(11) NOT NULL DEFAULT 1,
  `App` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `faction`
--

INSERT INTO `faction` (`id`, `type`, `name`, `abbrev`, `leader`, `motd`, `color`, `stock`, `logo`, `verify`, `description`, `armory_x`, `armory_y`, `armory_z`, `armory_gun_0`, `armory_stock_0`, `armory_price_0`, `armory_gun_1`, `armory_stock_1`, `armory_price_1`, `armory_gun_2`, `armory_stock_2`, `armory_price_2`, `armory_gun_3`, `armory_stock_3`, `armory_price_3`, `armory_gun_4`, `armory_stock_4`, `armory_price_4`, `armory_gun_5`, `armory_stock_5`, `armory_price_5`, `armory_gun_6`, `armory_stock_6`, `armory_price_6`, `armory_gun_7`, `armory_stock_7`, `armory_price_7`, `armory_gun_8`, `armory_stock_8`, `armory_price_8`, `armory_gun_9`, `armory_stock_9`, `armory_price_9`, `armory_gun_10`, `armory_stock_10`, `armory_price_10`, `armory_gun_11`, `armory_stock_11`, `armory_price_11`, `armory_gun_12`, `armory_stock_12`, `armory_price_12`, `armory_gun_13`, `armory_stock_13`, `armory_price_13`, `armory_gun_14`, `armory_stock_14`, `armory_price_14`, `armory_gun_15`, `armory_stock_15`, `armory_price_15`, `armory_gun_16`, `armory_stock_16`, `armory_price_16`, `armory_gun_17`, `armory_stock_17`, `armory_price_17`, `armory_gun_18`, `armory_stock_18`, `armory_price_18`, `armory_gun_19`, `armory_stock_19`, `armory_price_19`, `zone_color`, `level`, `App`) VALUES
(0, 4, 'Staff', 'empty', 1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(1, 1, 'LSPD', 'LSPD', 27, 's', 'empty', 100, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 452, -980, 31, 'Combatpistol', 0, 0, 'Snspistol', 0, 0, 'Stungun', 0, 0, 'Smg', 7, 0, 'Carbinerifle', 5, 0, 'Pumpshotgun', 10, 0, '9mm', 0, 0, '7.62', 0, 0, '12x3mm', 0, 0, '.45', 0, 0, 'Nightstick', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(2, 2, 'EMS', 'empty', 11, 's', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(3, 6, 'Mehanicar', 'empty', 17, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(4, 4, 'GSF', 'empty', 27, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(5, 4, 'Ballas', 'empty', 11, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(6, 4, 'LSV', 'empty', 11, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(7, 4, 'VLA', 'empty', 1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(8, 5, 'The HD Family', 'empty', 27, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(9, 5, 'Elites', 'empty', 12, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(10, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(11, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(12, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(13, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(14, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(15, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(16, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(17, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(18, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(19, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 1, 1, 0),
(20, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(21, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(22, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(23, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(24, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(25, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(26, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(27, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(28, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(29, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(30, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(31, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(32, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(33, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(34, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(35, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(36, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(37, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(38, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(39, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(40, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(41, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(42, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(43, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(44, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(45, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(46, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(47, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(48, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(49, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0),
(50, 5, 'empty', 'empty', -1, 'empty', 'empty', 0, 'https://i.imgur.com/BRSSf6F.png', 0, 'Sem DescriÃƒÆ’Ã‚Â§ÃƒÆ’Ã‚Â£o', 0, 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, '0', 0, 0, 0, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `faction_invite`
--

CREATE TABLE `faction_invite` (
  `id` int(11) NOT NULL,
  `name` tinytext DEFAULT NULL,
  `player` int(11) DEFAULT 0,
  `factionid` int(11) DEFAULT 0,
  `date` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `faction_rank`
--

CREATE TABLE `faction_rank` (
  `id` int(11) NOT NULL,
  `rank_0` varchar(32) DEFAULT 'indefinido',
  `salary_0` int(11) DEFAULT 0,
  `rank_1` varchar(32) DEFAULT 'indefinido',
  `salary_1` int(11) DEFAULT 0,
  `rank_2` varchar(32) DEFAULT 'indefinido',
  `salary_2` int(11) DEFAULT 0,
  `rank_3` varchar(32) DEFAULT 'indefinido',
  `salary_3` int(11) DEFAULT 0,
  `rank_4` varchar(32) DEFAULT 'indefinido',
  `salary_4` int(11) DEFAULT 0,
  `rank_5` varchar(32) DEFAULT 'indefinido',
  `salary_5` int(11) DEFAULT 0,
  `rank_6` varchar(32) DEFAULT 'indefinido',
  `salary_6` int(11) DEFAULT 0,
  `rank_7` varchar(32) DEFAULT 'indefinido',
  `salary_7` int(11) DEFAULT 0,
  `rank_8` varchar(32) DEFAULT 'indefinido',
  `salary_8` int(11) DEFAULT 0,
  `rank_9` varchar(32) DEFAULT 'indefinido',
  `salary_9` int(11) DEFAULT 0,
  `rank_10` varchar(32) DEFAULT 'indefinido',
  `salary_10` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `faction_rank`
--

INSERT INTO `faction_rank` (`id`, `rank_0`, `salary_0`, `rank_1`, `salary_1`, `rank_2`, `salary_2`, `rank_3`, `salary_3`, `rank_4`, `salary_4`, `rank_5`, `salary_5`, `rank_6`, `salary_6`, `rank_7`, `salary_7`, `rank_8`, `salary_8`, `rank_9`, `salary_9`, `rank_10`, `salary_10`) VALUES
(0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'indefinido', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(1, 'Kadet', 1000, 'Officer 1', 1500, 'Officer 2', 2000, 'Detektiv 1', 2500, 'Detektiv 2', 3500, 'Detektiv 3', 5000, 'Sargent 1', 5500, 'Sargent 2', 6500, 'Leuthenent', 7500, 'Captain', 8500, 'Director', 9500),
(2, 'nema', 5000, 'nema', 6000, 'nema', 7000, 'nema', 8500, 'nema', 9000, 'nema', 9500, 'nema', 9700, 'nema', 10000, 'nema', 10500, 'nema', 11500, 'nema', 9500),
(3, 'nema', 3000, 'nema', 6000, 'nema', 7000, 'nema', 8000, 'nema', 9000, 'nema', 10000, 'nema', 10500, 'nema', 11000, 'nema', 11500, 'nema', 12000, 'nema', 16000),
(4, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'Smoke', 0),
(5, 'nema', 0, 'nema', 0, 'nema', 600, 'nema', 700, 'nema', 800, 'nema', 900, 'nema', 1100, 'nema', 1300, 'nema', 1500, 'nema', 1800, 'nema', 2000),
(6, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(7, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(8, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'theHD', 0),
(9, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(10, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(11, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(12, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(13, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(14, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(15, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(16, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(17, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(18, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(19, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0),
(20, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0, 'nema', 0);

-- --------------------------------------------------------

--
-- Table structure for table `faction_werehouse`
--

CREATE TABLE `faction_werehouse` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT 'indefinido',
  `ownerid` int(11) DEFAULT -1,
  `price` int(11) DEFAULT 9999999,
  `safe` int(11) DEFAULT 0,
  `type` int(11) DEFAULT 0,
  `exterior_x` float DEFAULT 0,
  `exterior_y` float DEFAULT 0,
  `exterior_z` float DEFAULT 0,
  `exterior_a` float DEFAULT 0,
  `interior_x` float DEFAULT 0,
  `interior_y` float DEFAULT 0,
  `interior_z` float DEFAULT 0,
  `interior_a` float DEFAULT 0,
  `menu_x` float DEFAULT 0,
  `menu_y` float DEFAULT 0,
  `menu_z` float DEFAULT 0,
  `gun_0` varchar(32) DEFAULT 'indefinido',
  `gun_units_0` int(11) DEFAULT 0,
  `gun_perm_0` int(11) DEFAULT 0,
  `gun_1` varchar(32) DEFAULT 'indefinido',
  `gun_units_1` int(11) DEFAULT 0,
  `gun_perm_1` int(11) DEFAULT 0,
  `gun_2` varchar(32) DEFAULT 'indefinido',
  `gun_units_2` int(11) DEFAULT 0,
  `gun_perm_2` int(11) DEFAULT 0,
  `gun_3` varchar(32) DEFAULT 'indefinido',
  `gun_units_3` int(11) DEFAULT 0,
  `gun_perm_3` int(11) DEFAULT 0,
  `gun_4` varchar(32) DEFAULT 'indefinido',
  `gun_units_4` int(11) DEFAULT 0,
  `gun_perm_4` int(11) DEFAULT 0,
  `gun_5` varchar(32) DEFAULT 'indefinido',
  `gun_units_5` int(11) DEFAULT 0,
  `gun_perm_5` int(11) DEFAULT 0,
  `gun_6` varchar(32) DEFAULT 'indefinido',
  `gun_units_6` int(11) DEFAULT 0,
  `gun_perm_6` int(11) DEFAULT 0,
  `gun_7` varchar(32) DEFAULT 'indefinido',
  `gun_units_7` int(11) DEFAULT 0,
  `gun_perm_7` int(11) DEFAULT 0,
  `gun_8` varchar(32) DEFAULT 'indefinido',
  `gun_units_8` int(11) DEFAULT 0,
  `gun_perm_8` int(11) DEFAULT 0,
  `gun_9` varchar(32) DEFAULT 'indefinido',
  `gun_units_9` int(11) DEFAULT 0,
  `gun_perm_9` int(11) DEFAULT 0,
  `gun_10` varchar(32) DEFAULT 'indefinido',
  `gun_units_10` int(11) DEFAULT 0,
  `gun_perm_10` int(11) DEFAULT 0,
  `gun_11` varchar(32) DEFAULT 'indefinido',
  `gun_units_11` int(11) DEFAULT 0,
  `gun_perm_11` int(11) DEFAULT 0,
  `gun_12` varchar(32) DEFAULT 'indefinido',
  `gun_units_12` int(11) DEFAULT 0,
  `gun_perm_12` int(11) DEFAULT 0,
  `gun_13` varchar(32) DEFAULT 'indefinido',
  `gun_units_13` int(11) DEFAULT 0,
  `gun_perm_13` int(11) DEFAULT 0,
  `gun_14` varchar(32) DEFAULT 'indefinido',
  `gun_units_14` int(11) DEFAULT 0,
  `gun_perm_14` int(11) DEFAULT 0,
  `gun_15` varchar(32) DEFAULT 'indefinido',
  `gun_units_15` int(11) DEFAULT 0,
  `gun_perm_15` int(11) DEFAULT 0,
  `gun_16` varchar(32) DEFAULT 'indefinido',
  `gun_units_16` int(11) DEFAULT 0,
  `gun_perm_16` int(11) DEFAULT 0,
  `gun_17` varchar(32) DEFAULT 'indefinido',
  `gun_units_17` int(11) DEFAULT 0,
  `gun_perm_17` int(11) DEFAULT 0,
  `gun_18` varchar(32) DEFAULT 'indefinido',
  `gun_units_18` int(11) DEFAULT 0,
  `gun_perm_18` int(11) DEFAULT 0,
  `gun_19` varchar(32) DEFAULT 'indefinido',
  `gun_units_19` int(11) DEFAULT 0,
  `gun_perm_19` int(11) DEFAULT 0,
  `safe_gun_0` varchar(32) DEFAULT 'indefinido',
  `safe_gun_1` varchar(32) DEFAULT 'indefinido',
  `safe_gun_2` varchar(32) DEFAULT 'indefinido',
  `safe_gun_3` varchar(32) DEFAULT 'indefinido',
  `safe_gun_4` varchar(32) DEFAULT 'indefinido',
  `safe_gun_5` varchar(32) DEFAULT 'indefinido',
  `safe_gun_6` varchar(32) DEFAULT 'indefinido',
  `safe_gun_7` varchar(32) DEFAULT 'indefinido',
  `safe_gun_8` varchar(32) DEFAULT 'indefinido',
  `safe_gun_9` varchar(32) DEFAULT 'indefinido',
  `safe_gun_10` varchar(32) DEFAULT 'indefinido',
  `safe_gun_11` varchar(32) DEFAULT 'indefinido',
  `safe_gun_12` varchar(32) DEFAULT 'indefinido',
  `safe_gun_13` varchar(32) DEFAULT 'indefinido',
  `safe_gun_14` varchar(32) DEFAULT 'indefinido',
  `safe_gun_15` varchar(32) DEFAULT 'indefinido',
  `safe_gun_16` varchar(32) DEFAULT 'indefinido',
  `safe_gun_17` varchar(32) DEFAULT 'indefinido',
  `safe_gun_18` varchar(32) DEFAULT 'indefinido',
  `safe_gun_19` varchar(32) DEFAULT 'indefinido',
  `safe_gun_20` varchar(32) DEFAULT 'indefinido'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `faction_werehouse`
--

INSERT INTO `faction_werehouse` (`id`, `name`, `ownerid`, `price`, `safe`, `type`, `exterior_x`, `exterior_y`, `exterior_z`, `exterior_a`, `interior_x`, `interior_y`, `interior_z`, `interior_a`, `menu_x`, `menu_y`, `menu_z`, `gun_0`, `gun_units_0`, `gun_perm_0`, `gun_1`, `gun_units_1`, `gun_perm_1`, `gun_2`, `gun_units_2`, `gun_perm_2`, `gun_3`, `gun_units_3`, `gun_perm_3`, `gun_4`, `gun_units_4`, `gun_perm_4`, `gun_5`, `gun_units_5`, `gun_perm_5`, `gun_6`, `gun_units_6`, `gun_perm_6`, `gun_7`, `gun_units_7`, `gun_perm_7`, `gun_8`, `gun_units_8`, `gun_perm_8`, `gun_9`, `gun_units_9`, `gun_perm_9`, `gun_10`, `gun_units_10`, `gun_perm_10`, `gun_11`, `gun_units_11`, `gun_perm_11`, `gun_12`, `gun_units_12`, `gun_perm_12`, `gun_13`, `gun_units_13`, `gun_perm_13`, `gun_14`, `gun_units_14`, `gun_perm_14`, `gun_15`, `gun_units_15`, `gun_perm_15`, `gun_16`, `gun_units_16`, `gun_perm_16`, `gun_17`, `gun_units_17`, `gun_perm_17`, `gun_18`, `gun_units_18`, `gun_perm_18`, `gun_19`, `gun_units_19`, `gun_perm_19`, `safe_gun_0`, `safe_gun_1`, `safe_gun_2`, `safe_gun_3`, `safe_gun_4`, `safe_gun_5`, `safe_gun_6`, `safe_gun_7`, `safe_gun_8`, `safe_gun_9`, `safe_gun_10`, `safe_gun_11`, `safe_gun_12`, `safe_gun_13`, `safe_gun_14`, `safe_gun_15`, `safe_gun_16`, `safe_gun_17`, `safe_gun_18`, `safe_gun_19`, `safe_gun_20`) VALUES
(0, 'GSF', 4, 0, 80, 1, -14.11, -1442.14, 31.1, 0, -1577.78, -563.474, 108.523, 0, -137.082, -1608.55, 35.0302, 'Bat', 4, 0, 'SwitchBlade', 4, 0, 'PoolCue', 5, 0, 'KnuckleDuster', 5, 0, 'Revolver', 5, 0, 'VintagePistol', 5, 0, 'DoubleAction', 5, 0, 'MicroSMG', 5, 0, 'MachinePistol', 5, 0, 'MiniSMG', 4, 0, 'DoubleBarrelShotgun', 5, 0, 'PumpShotgun', 5, 0, 'AssaultSMG', 5, 0, 'CombatPDW', 5, 0, 'AssaultRifle', 5, 0, 'MG', 4, 0, 'Gusenberg', 3, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'Unknown', 'Unknown', 'Unknown', 'Unknown', 'Unknown', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(1, 'BALLAS', 5, 9999999, 0, 1, 85.52, -1959.51, 21.12, 0, 0, 0, 0, 0, 106.366, -1981.3, 20.9626, 'Bat', 4, 0, 'SwitchBlade', 4, 0, 'PoolCue', 4, 0, 'KnuckleDuster', 4, 0, 'Revolver', 3, 0, 'VintagePistol', 4, 0, 'DoubleAction', 4, 0, 'MicroSMG', 4, 0, 'MachinePistol', 5, 0, 'MiniSMG', 4, 0, 'DoubleBarrelShotgun', 4, 0, 'PumpShotgun', 4, 0, 'AssaultSMG', 4, 0, 'CombatPDW', 3, 0, 'AssaultRifle', 4, 0, 'MG', 4, 0, 'Gusenberg', 4, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(2, 'VAGOS', 6, 9999999, 0, 2, 325.83, -2050.53, 20.93, 0, 0, 0, 0, 0, 330.072, -2014.5, 22.395, 'Bat', 3, 0, 'SwitchBlade', 4, 0, 'PoolCue', 3, 0, 'KnuckleDuster', 3, 0, 'Revolver', 4, 0, 'VintagePistol', 5, 0, 'DoubleAction', 4, 0, 'MicroSMG', 4, 0, 'MachinePistol', 4, 0, 'MiniSMG', 3, 0, 'DoubleBarrelShotgun', 4, 0, 'PumpShotgun', 4, 0, 'AssaultSMG', 4, 0, 'CombatPDW', 4, 0, 'AssaultRifle', 3, 0, 'MG', 4, 0, 'Gusenberg', 3, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(3, 'AZTECAS', 7, 9999999, 0, 2, 479.53, -1736.1, 29.51, 0, 0, 0, 0, 0, 1439.52, -1489.36, 66.6193, 'Bat', 5, 0, 'SwitchBlade', 5, 0, 'PoolCue', 5, 0, 'KnuckleDuster', 5, 0, 'Revolver', 5, 0, 'VintagePistol', 5, 0, 'DoubleAction', 5, 0, 'MicroSMG', 5, 0, 'MachinePistol', 5, 0, 'MiniSMG', 5, 0, 'DoubleBarrelShotgun', 5, 0, 'PumpShotgun', 5, 0, 'AssaultSMG', 5, 0, 'CombatPDW', 5, 0, 'AssaultRifle', 5, 0, 'MG', 5, 0, 'Gusenberg', 5, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(4, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 5, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(5, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(6, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(7, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(8, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(9, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(10, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(11, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(12, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(13, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(14, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(15, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(16, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(17, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(18, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(19, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido'),
(20, 'nema', -1, 9999999, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 0, 0, 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido', 'indefinido');

-- --------------------------------------------------------

--
-- Table structure for table `fines`
--

CREATE TABLE `fines` (
  `id` int(11) NOT NULL,
  `suspect` varchar(50) NOT NULL DEFAULT '0',
  `description` varchar(512) NOT NULL DEFAULT '0',
  `price` smallint(6) NOT NULL DEFAULT 0,
  `officer` varchar(70) NOT NULL DEFAULT '0',
  `ispaid` tinyint(4) NOT NULL DEFAULT 0,
  `date` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `furnitures`
--

CREATE TABLE `furnitures` (
  `id` int(11) NOT NULL,
  `house` int(11) DEFAULT -1,
  `name` varchar(64) DEFAULT '0',
  `model` varchar(64) DEFAULT '0',
  `model_name` varchar(64) DEFAULT '0',
  `price` int(11) DEFAULT 0,
  `status` int(11) DEFAULT 0,
  `position_x` varchar(255) DEFAULT '0',
  `position_y` varchar(255) DEFAULT '0',
  `position_z` varchar(255) DEFAULT '0',
  `rotation_x` varchar(255) DEFAULT '0',
  `rotation_y` varchar(255) DEFAULT '0',
  `rotation_z` varchar(255) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `garagem`
--

CREATE TABLE `garagem` (
  `id` int(11) NOT NULL,
  `position_x` float DEFAULT 0,
  `position_y` float DEFAULT 0,
  `position_z` float DEFAULT 0,
  `position_a` float DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `garagem`
--

INSERT INTO `garagem` (`id`, `position_x`, `position_y`, `position_z`, `position_a`) VALUES
(0, 224.047, -802.826, 30.6388, 0),
(1, 287.444, -340.796, 44.9199, 0),
(2, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `garbages`
--

CREATE TABLE `garbages` (
  `id` int(11) NOT NULL,
  `position_x` varchar(32) DEFAULT '0',
  `position_y` varchar(32) DEFAULT '0',
  `position_z` varchar(32) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `garbages`
--

INSERT INTO `garbages` (`id`, `position_x`, `position_y`, `position_z`) VALUES
(101, '971.1552', '-1702.762', '29.73825'),
(102, '816.8897', '-1628.048', '31.18791'),
(103, '795.8561', '-2529.934', '21.56392'),
(104, '628.9395', '-2993.428', '6.019532'),
(105, '845.6927', '-3245.5', '6.074312'),
(106, '555.4387', '-2297.55', '5.953637'),
(107, '809.4142', '-2118.997', '29.33709'),
(108, '1557.957', '-2125.584', '77.36517'),
(109, '1741.874', '-1679.833', '112.6547'),
(110, '1169.275', '-1649.895', '36.77785'),
(111, '1196.663', '-1272.252', '35.22519'),
(112, '1128.905', '-993.2784', '45.9543'),
(113, '1116.258', '-343.4794', '67.03443'),
(114, '980.3447', '-120.3409', '73.92935'),
(115, '493.9371', '-634.2559', '24.88715'),
(116, '756.0276', '-785.7494', '26.29788'),
(117, '740.8499', '-987.2206', '24.63326'),
(118, '482.918', '-1278.355', '29.55381'),
(119, '489.3528', '-1512.658', '29.28905'),
(120, '299.4818', '-1733.393', '29.31607'),
(121, '119.9798', '-2063.204', '18.02604'),
(122, '149.281', '-2642.399', '5.99794'),
(123, '-313.8573', '-2725.414', '6.042042'),
(124, '-287.6905', '-2402.594', '6.00062'),
(125, '157.2907', '-3314.076', '6.059582'),
(126, '375.1671', '353.7056', '102.7047'),
(127, '543.4445', '-206.1309', '54.1363'),
(128, '477.4509', '-1062.844', '29.21143'),
(129, '-119.7945', '215.4048', '94.15034'),
(130, '136.553', '-344.3672', '43.60726'),
(131, '-207.0139', '219.2221', '87.73296'),
(132, '-399.3051', '180.8185', '80.25071'),
(133, '-701.6128', '-723.9596', '28.75306'),
(134, '-348.5521', '-102.263', '45.66384'),
(135, '-726.407', '-428.1504', '35.32195'),
(136, '-624.1619', '292.3147', '81.95654'),
(137, '-603.3878', '-982.7878', '22.08349'),
(138, '-532.5589', '-1778.719', '21.43597'),
(139, '-87.68831', '-1330.209', '29.23748'),
(140, '0.1992107', '-1480.079', '31.65015'),
(141, '-1083.043', '-1665.847', '4.704968'),
(142, '-1213.913', '-1425.682', '4.354013'),
(143, '-1094.365', '-1253.682', '5.358323'),
(144, '-1302.041', '-781.9444', '18.03249'),
(145, '-1566.874', '-425.4126', '37.92418'),
(146, '-1395.185', '-445.19', '34.58551'),
(147, '51.93162', '-831.7758', '31.07571'),
(148, '33.67869', '-1010.851', '29.4489'),
(149, '-327.8728', '-1319.108', '31.41377'),
(150, '-142.7485', '-2236.364', '7.811677');

-- --------------------------------------------------------

--
-- Table structure for table `glog`
--

CREATE TABLE `glog` (
  `id` int(11) NOT NULL,
  `Type` tinytext DEFAULT NULL,
  `Text` text DEFAULT NULL,
  `Time` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `govcamera`
--

CREATE TABLE `govcamera` (
  `id` int(11) NOT NULL,
  `camname` tinytext NOT NULL,
  `posx` float(255,0) NOT NULL,
  `posy` float(255,0) NOT NULL,
  `posz` float(255,0) NOT NULL,
  `rotx` float(255,0) NOT NULL,
  `roty` float(255,0) NOT NULL,
  `rotz` float(255,0) NOT NULL,
  `fov` float(255,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `govcamera`
--

INSERT INTO `govcamera` (`id`, `camname`, `posx`, `posy`, `posz`, `rotx`, `roty`, `rotz`, `fov`) VALUES
(5, 'Senora desert', 2648, 3165, 57, 0, 0, 303, 100),
(6, 'Senora desert 2', 2677, 3144, 57, 0, 0, 122, 100),
(7, '68 #1', -2694, 2315, 38, 0, 0, 118, 100),
(8, 'Great ocean', -2723, 2322, 32, 0, 0, 323, 100),
(9, '68 #2', -952, 2765, 38, 0, 0, 114, 100),
(10, '68 #3', -505, 2853, 49, 0, 0, 244, 100),
(11, '68 #4', 1324, 2754, 66, 0, 0, 137, 100);

-- --------------------------------------------------------

--
-- Table structure for table `graf`
--

CREATE TABLE `graf` (
  `id` int(11) NOT NULL,
  `pos` varchar(50) DEFAULT '',
  `rot` varchar(50) DEFAULT '',
  `band` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `graf`
--

INSERT INTO `graf` (`id`, `pos`, `rot`, `band`) VALUES
(0, '{\"x\":288.00,\"y\":-1694.39,\"z\":29.38}', '{\"x\":0,\"y\":0,\"z\":140.42}', 4),
(1, '{\"x\":69.257,\"y\":-1385.972,\"z\":29.27204}', '{\"x\":0,\"y\":0,\"z\":180.00182}', 4),
(2, '{\"x\":11.834,\"y\":-1532.392,\"z\":29.3063}', '{\"x\":0,\"y\":0,\"z\":50.5099}', 4),
(3, '{\"x\":-14.4554,\"y\":-1822.430,\"z\":25.40412}', '{\"x\":0,\"y\":0,\"z\":-131.337}', 4),
(4, '{\"x\":150.749,\"y\":-1555.444,\"z\":29.73452}', '{\"x\":0,\"y\":0,\"z\":-46.020}', 4),
(5, '{\"x\":89.6132,\"y\":-1297.966,\"z\":29.80521}', '{\"x\":0,\"y\":0,\"z\":-60.299}', 4),
(6, '{\"x\":40.9336,\"y\":-1197.405,\"z\":29.000}', '{\"x\":0,\"y\":0,\"z\":90.0592}', 3),
(7, '{\"x\":117.38,\"y\":-1332.155,\"z\":29.5062}', '{\"x\":0,\"y\":0,\"z\":-142.5793}', 4),
(8, '{\"x\":352.5104,\"y\":-1572.15,\"z\":29.54379}', '{\"x\":0,\"y\":0,\"z\":48.819}', 4),
(9, '{\"x\":292.981,\"y\":-1636.886,\"z\":27.40623}', '{\"x\":0,\"y\":0,\"z\":-40.0677}', 4),
(10, '{\"x\":119.09,\"y\":-1951.181,\"z\":20.6642}', '{\"x\":0,\"y\":0,\"z\":-128.4198}', 6),
(11, '{\"x\":-163.681,\"y\":-1675.702,\"z\":33.52413}', '{\"x\":0,\"y\":0,\"z\":-129.8598}', 6),
(12, '{\"x\":457.78,\"y\":-1245.887,\"z\":30.01235}', '{\"x\":0,\"y\":0,\"z\":0.00988}', 7),
(13, '{\"x\":750.142,\"y\":-1721.362,\"z\":29.7399}', '{\"x\":0,\"y\":0,\"z\":-4.579989}', 7),
(14, '{\"x\":106.11,\"y\":-1489.39,\"z\":35.28657}', '{\"x\":0,\"y\":0,\"z\":-130.66494}', 7);

-- --------------------------------------------------------

--
-- Table structure for table `houses`
--

CREATE TABLE `houses` (
  `id` int(11) NOT NULL,
  `name` varchar(128) DEFAULT 'undefined',
  `owner` int(11) DEFAULT -1,
  `owner_name` varchar(128) DEFAULT 'undefined',
  `price` int(11) DEFAULT 0,
  `safe` int(11) DEFAULT 0,
  `vip` int(11) DEFAULT 0,
  `lock_status` int(11) DEFAULT 0,
  `sell_house` int(11) DEFAULT 0,
  `exterior_x` varchar(128) DEFAULT '0',
  `exterior_y` varchar(128) DEFAULT '0',
  `exterior_z` varchar(128) DEFAULT '0',
  `exterior_a` varchar(128) DEFAULT '0',
  `interior_x` varchar(128) DEFAULT '0',
  `interior_y` varchar(128) DEFAULT '0',
  `interior_z` varchar(128) DEFAULT '0',
  `interior_a` varchar(128) DEFAULT '0',
  `exterior_garage_x` varchar(128) DEFAULT '0',
  `exterior_garage_y` varchar(128) DEFAULT '0',
  `exterior_garage_z` varchar(128) DEFAULT '0',
  `exterior_garage_a` varchar(128) DEFAULT '0',
  `in_garage` tinyint(4) DEFAULT 0,
  `garage_slot` tinyint(4) DEFAULT 1,
  `house_key_0` varchar(128) DEFAULT '0',
  `house_key_1` varchar(128) DEFAULT '0',
  `house_key_2` varchar(128) DEFAULT '0',
  `house_key_3` varchar(128) DEFAULT '0',
  `house_key_4` varchar(128) DEFAULT '0',
  `house_key_5` varchar(128) DEFAULT '0',
  `house_key_6` varchar(128) DEFAULT '0',
  `house_key_7` varchar(128) DEFAULT '0',
  `house_key_8` varchar(128) DEFAULT '0',
  `house_key_9` varchar(128) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `houses`
--

INSERT INTO `houses` (`id`, `name`, `owner`, `owner_name`, `price`, `safe`, `vip`, `lock_status`, `sell_house`, `exterior_x`, `exterior_y`, `exterior_z`, `exterior_a`, `interior_x`, `interior_y`, `interior_z`, `interior_a`, `exterior_garage_x`, `exterior_garage_y`, `exterior_garage_z`, `exterior_garage_a`, `in_garage`, `garage_slot`, `house_key_0`, `house_key_1`, `house_key_2`, `house_key_3`, `house_key_4`, `house_key_5`, `house_key_6`, `house_key_7`, `house_key_8`, `house_key_9`) VALUES
(0, 'Velika', 11, 'Hade_Fhd', 1460887, 0, 0, 0, 0, '-113.73995', '985.64087', '235.75415', '-71.59639', '346.5961', '-1002.541', '-99.19624', '357.6783', '0', '0', '0', '0', 0, 4, '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `id` int(11) NOT NULL,
  `owner` int(11) DEFAULT -1,
  `type` int(11) DEFAULT 0,
  `amount` int(11) DEFAULT 0,
  `dropable` tinyint(4) NOT NULL DEFAULT 1,
  `inuse` tinyint(4) DEFAULT 0,
  `slotid` int(11) DEFAULT -1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `inventory_house`
--

CREATE TABLE `inventory_house` (
  `id` int(11) NOT NULL,
  `owner` int(11) DEFAULT -1,
  `type` int(11) DEFAULT 0,
  `amount` int(11) DEFAULT 0,
  `slotid` int(11) DEFAULT -1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `inventory_hq`
--

CREATE TABLE `inventory_hq` (
  `id` int(11) NOT NULL,
  `owner` int(11) DEFAULT -1,
  `type` int(11) DEFAULT 0,
  `amount` int(11) DEFAULT 0,
  `slotid` int(11) DEFAULT -1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `kenny_applications`
--

CREATE TABLE `kenny_applications` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `UserName` varchar(15) NOT NULL,
  `CreatedDate` varchar(25) NOT NULL,
  `Status` int(11) NOT NULL DEFAULT 0,
  `AnswerID` int(11) NOT NULL,
  `AnswerName` varchar(15) NOT NULL,
  `AnswerIP` varchar(20) NOT NULL,
  `AnswerDate` varchar(25) NOT NULL,
  `Reason` varchar(50) NOT NULL,
  `Questions` int(11) NOT NULL,
  `Answers` text NOT NULL,
  `FactionID` int(11) NOT NULL,
  `Type` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `kenny_badges`
--

CREATE TABLE `kenny_badges` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `Text` varchar(20) NOT NULL,
  `Color` varchar(20) NOT NULL,
  `Icon` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `kenny_badges`
--

INSERT INTO `kenny_badges` (`ID`, `UserID`, `Text`, `Color`, `Icon`) VALUES
(2, 17, 'Owner', '#a6ff00', 'cog');

-- --------------------------------------------------------

--
-- Table structure for table `kenny_comments`
--

CREATE TABLE `kenny_comments` (
  `ID` int(11) NOT NULL,
  `cID` int(11) NOT NULL,
  `UserName` varchar(50) NOT NULL,
  `UserID` int(11) NOT NULL,
  `Date` varchar(25) NOT NULL,
  `Text` text NOT NULL,
  `Type` varchar(15) NOT NULL,
  `Skin` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `kenny_complaints`
--

CREATE TABLE `kenny_complaints` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `UserName` varchar(50) NOT NULL,
  `AgainstName` varchar(50) NOT NULL,
  `AgainstID` int(11) NOT NULL,
  `Details` text NOT NULL,
  `Category` varchar(50) NOT NULL,
  `CreatedDate` varchar(50) NOT NULL,
  `AnswerDate` varchar(50) NOT NULL DEFAULT '0',
  `Proofs` varchar(150) NOT NULL,
  `Faction` int(11) NOT NULL DEFAULT 0,
  `CreatorIP` varchar(50) NOT NULL DEFAULT '0',
  `AnswerIP` varchar(50) NOT NULL DEFAULT '0',
  `AnswerName` varchar(50) NOT NULL DEFAULT '-',
  `AnswerID` int(11) NOT NULL DEFAULT 0,
  `Status` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `kenny_complaints`
--

INSERT INTO `kenny_complaints` (`ID`, `UserID`, `UserName`, `AgainstName`, `AgainstID`, `Details`, `Category`, `CreatedDate`, `AnswerDate`, `Proofs`, `Faction`, `CreatorIP`, `AnswerIP`, `AnswerName`, `AnswerID`, `Status`) VALUES
(1, 21, 'John_Patrone', 'Blaze_Capone', 20, 'Test zalbe', 'Ostalo', '09.02.2023 16:56', '09.02.2023 17:13', 'dokaz 1# dokaz 2#', 2, '::1', '0', 'Hadehd', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `kenny_editables`
--

CREATE TABLE `kenny_editables` (
  `ID` int(11) NOT NULL,
  `EditedBy` varchar(15) NOT NULL,
  `EditedDate` varchar(25) NOT NULL,
  `Text` text NOT NULL,
  `Type` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `kenny_editables`
--

INSERT INTO `kenny_editables` (`ID`, `EditedBy`, `EditedDate`, `Text`, `Type`) VALUES
(1, 'Test_Test', '09.02.2023 14:31', 'Novosti sa servera', 'News');

-- --------------------------------------------------------

--
-- Table structure for table `kenny_logs`
--

CREATE TABLE `kenny_logs` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `AdminID` int(11) NOT NULL,
  `Text` varchar(250) NOT NULL,
  `Date` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `kenny_logs`
--

INSERT INTO `kenny_logs` (`ID`, `UserID`, `AdminID`, `Text`, `Date`) VALUES
(1, 17, 17, '[+] Admin Test_Test je dodao kolonu (Money) igracu Test_Test -> [ 5 ].', '08.02.2023 00:20');

-- --------------------------------------------------------

--
-- Table structure for table `kenny_questions`
--

CREATE TABLE `kenny_questions` (
  `ID` int(11) NOT NULL,
  `CreatedBy` varchar(50) NOT NULL,
  `CreatedDate` varchar(25) NOT NULL,
  `Question` text NOT NULL,
  `FactionID` int(11) NOT NULL,
  `Type` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `kenny_recovery`
--

CREATE TABLE `kenny_recovery` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `UserName` varchar(60) NOT NULL,
  `Email` varchar(60) NOT NULL,
  `SecretCode` varchar(60) NOT NULL,
  `RecoveryTime` int(11) NOT NULL,
  `Type` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `kenny_tickets`
--

CREATE TABLE `kenny_tickets` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `UserName` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Details` text NOT NULL,
  `CreatedDate` varchar(25) NOT NULL,
  `AnswerDate` varchar(25) NOT NULL DEFAULT '0',
  `CreatorIP` varchar(50) NOT NULL DEFAULT '0',
  `AnswerIP` varchar(50) NOT NULL DEFAULT '0',
  `AnswerID` int(11) NOT NULL DEFAULT 0,
  `AnswerName` varchar(50) NOT NULL DEFAULT '-',
  `Status` int(11) NOT NULL DEFAULT 0,
  `ForOwner` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `kenny_tickets`
--

INSERT INTO `kenny_tickets` (`ID`, `UserID`, `UserName`, `Category`, `Details`, `CreatedDate`, `AnswerDate`, `CreatorIP`, `AnswerIP`, `AnswerID`, `AnswerName`, `Status`, `ForOwner`) VALUES
(2, 21, 'John_Patrone', 'Forum/Panel', 'Test', '09.02.2023 16:56', '0', '::1', '0', 0, '-', 0, 0),
(3, 21, 'John_Patrone', 'Server', 'Test prijave', '09.02.2023 16:57', '09.02.2023 17:18', '::1', '0', 0, 'Hadehd', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `kenny_unbans`
--

CREATE TABLE `kenny_unbans` (
  `ID` int(11) NOT NULL,
  `Status` int(11) NOT NULL DEFAULT 0,
  `UserID` int(11) NOT NULL,
  `UserName` varchar(50) NOT NULL,
  `Proofs` text NOT NULL,
  `Details` text NOT NULL,
  `CreatedDate` varchar(25) NOT NULL,
  `AnswerDate` varchar(25) NOT NULL DEFAULT '0',
  `CreatorIP` varchar(50) NOT NULL,
  `AnswerIP` varchar(50) NOT NULL DEFAULT '0',
  `AnswerName` varchar(50) NOT NULL DEFAULT '-',
  `AnswerID` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `kenny_unbans`
--

INSERT INTO `kenny_unbans` (`ID`, `Status`, `UserID`, `UserName`, `Proofs`, `Details`, `CreatedDate`, `AnswerDate`, `CreatorIP`, `AnswerIP`, `AnswerName`, `AnswerID`) VALUES
(2, 0, 21, 'John_Patrone', 'Test dokaz', 'Test tekst', '09.02.2023 16:53', '0', '::1', '0', '-', 0);

-- --------------------------------------------------------

--
-- Table structure for table `known`
--

CREATE TABLE `known` (
  `id` int(11) NOT NULL,
  `player_one` int(11) DEFAULT -1,
  `player_two` int(11) DEFAULT -1,
  `name` tinytext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `mdc`
--

CREATE TABLE `mdc` (
  `id` int(11) NOT NULL,
  `type` int(11) DEFAULT NULL,
  `officer` tinytext NOT NULL,
  `suspect` tinytext DEFAULT NULL,
  `note` text DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `plate` tinytext DEFAULT NULL,
  `price` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `notes`
--

CREATE TABLE `notes` (
  `id` int(11) NOT NULL,
  `officer` varchar(34) NOT NULL DEFAULT 'unknown',
  `suspect` varchar(34) NOT NULL DEFAULT 'unknown',
  `description` varchar(512) NOT NULL DEFAULT '',
  `datetime` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

CREATE TABLE `payment` (
  `id` int(11) NOT NULL,
  `char_id` int(11) DEFAULT NULL,
  `billid` text DEFAULT NULL,
  `char_name` varchar(50) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `date` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `pdbadge`
--

CREATE TABLE `pdbadge` (
  `id` int(11) NOT NULL,
  `owner` int(11) DEFAULT 0,
  `bnumber` int(11) DEFAULT 0,
  `register_date` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `pquest`
--

CREATE TABLE `pquest` (
  `id` int(11) NOT NULL,
  `pid` int(11) NOT NULL DEFAULT 0,
  `char_name` varchar(50) NOT NULL DEFAULT '0',
  `questions_id` varchar(70) NOT NULL DEFAULT '0',
  `answers_id` varchar(70) NOT NULL DEFAULT '0',
  `fanswer` varchar(6) NOT NULL DEFAULT '0',
  `pending` tinyint(4) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `quests`
--

CREATE TABLE `quests` (
  `id` int(11) NOT NULL,
  `question` text DEFAULT NULL,
  `answer_slot` tinyint(4) NOT NULL DEFAULT 0,
  `correct_answer_id` tinyint(4) DEFAULT 0,
  `answer_0` text DEFAULT NULL,
  `answer_1` text DEFAULT NULL,
  `answer_2` text DEFAULT NULL,
  `answer_3` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `sellingcar`
--

CREATE TABLE `sellingcar` (
  `id` int(11) NOT NULL,
  `sell_point` text DEFAULT NULL,
  `sell_price` int(11) DEFAULT NULL,
  `sell_time` int(11) DEFAULT NULL,
  `sell_point_location_1` text DEFAULT NULL,
  `sell_point_vehsql_1` int(11) DEFAULT NULL,
  `sell_point_vehprice_1` int(11) DEFAULT NULL,
  `sell_point_starttime_1` int(11) DEFAULT NULL,
  `ownersqlid_1` int(11) DEFAULT NULL,
  `sell_point_location_2` text DEFAULT NULL,
  `sell_point_vehsql_2` int(11) DEFAULT NULL,
  `sell_point_vehprice_2` int(11) DEFAULT NULL,
  `sell_point_starttime_2` int(11) DEFAULT NULL,
  `ownersqlid_2` int(11) DEFAULT NULL,
  `sell_point_location_3` text DEFAULT NULL,
  `sell_point_vehsql_3` int(11) DEFAULT NULL,
  `sell_point_vehprice_3` int(11) DEFAULT NULL,
  `sell_point_starttime_3` int(11) DEFAULT NULL,
  `ownersqlid_3` int(11) DEFAULT NULL,
  `sell_point_location_4` text DEFAULT NULL,
  `sell_point_vehsql_4` int(11) DEFAULT NULL,
  `sell_point_vehprice_4` int(11) DEFAULT NULL,
  `sell_point_starttime_4` int(11) DEFAULT NULL,
  `ownersqlid_4` int(11) DEFAULT NULL,
  `sell_point_location_5` text DEFAULT NULL,
  `sell_point_vehsql_5` int(11) DEFAULT NULL,
  `sell_point_vehprice_5` int(11) DEFAULT NULL,
  `sell_point_starttime_5` int(11) DEFAULT NULL,
  `ownersqlid_5` int(11) DEFAULT NULL,
  `sell_point_location_6` text DEFAULT NULL,
  `sell_point_vehsql_6` int(11) DEFAULT NULL,
  `sell_point_vehprice_6` int(11) DEFAULT NULL,
  `sell_point_starttime_6` int(11) DEFAULT NULL,
  `ownersqlid_6` int(11) DEFAULT NULL,
  `sell_point_location_7` text DEFAULT NULL,
  `sell_point_vehsql_7` int(11) DEFAULT NULL,
  `sell_point_vehprice_7` int(11) DEFAULT NULL,
  `sell_point_starttime_7` int(11) DEFAULT NULL,
  `ownersqlid_7` int(11) DEFAULT NULL,
  `sell_point_location_8` text DEFAULT NULL,
  `sell_point_vehsql_8` int(11) DEFAULT NULL,
  `sell_point_vehprice_8` int(11) DEFAULT NULL,
  `sell_point_starttime_8` int(11) DEFAULT NULL,
  `ownersqlid_8` int(11) DEFAULT NULL,
  `sell_point_location_9` text DEFAULT NULL,
  `sell_point_vehsql_9` int(11) DEFAULT NULL,
  `sell_point_vehprice_9` int(11) DEFAULT NULL,
  `sell_point_starttime_9` int(11) DEFAULT NULL,
  `ownersqlid_9` int(11) DEFAULT NULL,
  `sell_point_location_10` text DEFAULT NULL,
  `sell_point_vehsql_10` int(11) DEFAULT NULL,
  `sell_point_vehprice_10` int(11) DEFAULT NULL,
  `sell_point_starttime_10` int(11) DEFAULT NULL,
  `ownersqlid_10` int(11) DEFAULT NULL,
  `sell_point_location_11` text DEFAULT NULL,
  `sell_point_vehsql_11` int(11) DEFAULT NULL,
  `sell_point_vehprice_11` int(11) DEFAULT NULL,
  `sell_point_starttime_11` int(11) DEFAULT NULL,
  `ownersqlid_11` int(11) DEFAULT NULL,
  `sell_point_location_12` text DEFAULT NULL,
  `sell_point_vehsql_12` int(11) DEFAULT NULL,
  `sell_point_vehprice_12` int(11) DEFAULT NULL,
  `sell_point_starttime_12` int(11) DEFAULT NULL,
  `ownersqlid_12` int(11) DEFAULT NULL,
  `sell_point_location_13` text DEFAULT NULL,
  `sell_point_vehsql_13` int(11) DEFAULT NULL,
  `sell_point_vehprice_13` int(11) DEFAULT NULL,
  `sell_point_starttime_13` int(11) DEFAULT NULL,
  `ownersqlid_13` int(11) DEFAULT NULL,
  `sell_point_location_14` text DEFAULT NULL,
  `sell_point_vehsql_14` int(11) DEFAULT NULL,
  `sell_point_vehprice_14` int(11) DEFAULT NULL,
  `sell_point_starttime_14` int(11) DEFAULT NULL,
  `ownersqlid_14` int(11) DEFAULT NULL,
  `sell_point_location_15` text DEFAULT NULL,
  `sell_point_vehsql_15` int(11) DEFAULT NULL,
  `sell_point_vehprice_15` int(11) DEFAULT NULL,
  `sell_point_starttime_15` int(11) DEFAULT NULL,
  `ownersqlid_15` int(11) DEFAULT NULL,
  `sell_point_location_16` text DEFAULT NULL,
  `sell_point_vehsql_16` int(11) DEFAULT NULL,
  `sell_point_vehprice_16` int(11) DEFAULT NULL,
  `sell_point_starttime_16` int(11) DEFAULT NULL,
  `ownersqlid_16` int(11) DEFAULT NULL,
  `sell_point_location_17` text DEFAULT NULL,
  `sell_point_vehsql_17` int(11) DEFAULT NULL,
  `sell_point_vehprice_17` int(11) DEFAULT NULL,
  `sell_point_starttime_17` int(11) DEFAULT NULL,
  `ownersqlid_17` int(11) DEFAULT NULL,
  `sell_point_location_18` text DEFAULT NULL,
  `sell_point_vehsql_18` int(11) DEFAULT NULL,
  `sell_point_vehprice_18` int(11) DEFAULT NULL,
  `sell_point_starttime_18` int(11) DEFAULT NULL,
  `ownersqlid_18` int(11) DEFAULT NULL,
  `sell_point_location_19` text DEFAULT NULL,
  `sell_point_vehsql_19` int(11) DEFAULT NULL,
  `sell_point_vehprice_19` int(11) DEFAULT NULL,
  `sell_point_starttime_19` int(11) DEFAULT NULL,
  `ownersqlid_19` int(11) DEFAULT NULL,
  `sell_point_location_20` text DEFAULT NULL,
  `sell_point_vehsql_20` int(11) DEFAULT NULL,
  `sell_point_vehprice_20` int(11) DEFAULT NULL,
  `sell_point_starttime_20` int(11) DEFAULT NULL,
  `ownersqlid_20` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `serverinfo`
--

CREATE TABLE `serverinfo` (
  `last_server_check` int(11) DEFAULT 0,
  `online_players` int(11) DEFAULT 0,
  `player_slot` int(11) DEFAULT 0,
  `server_name` char(50) DEFAULT 'No Name',
  `logo_url` char(50) DEFAULT 'No URL'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `serverinfo`
--

INSERT INTO `serverinfo` (`last_server_check`, `online_players`, `player_slot`, `server_name`, `logo_url`) VALUES
(1678741832, 0, 100, 'No Name', 'No URL'),
(1678741832, 0, 100, 'No Name', 'No URL');

-- --------------------------------------------------------

--
-- Table structure for table `server_log`
--

CREATE TABLE `server_log` (
  `log_type` varchar(50) DEFAULT NULL,
  `log_message` longtext DEFAULT NULL,
  `log_time` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `server_log`
--

INSERT INTO `server_log` (`log_type`, `log_message`, `log_time`) VALUES
('2', 'Xanis Xan Aslahe Model Smg Ammo: -4740 Daryaft Kard', '2023-02-04 18:04:12'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 18:04:25'),
('1', 'Xanis Xan  Has Received Cash  Value: 1', '2023-02-04 18:04:25'),
('2', 'Xanis Xan Aslahe Model Smg Ammo: -4740 Daryaft Kard', '2023-02-04 18:09:07'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 18:09:26'),
('1', 'Xanis Xan  Has Received Cash  Value: 1', '2023-02-04 18:09:26'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 18:09:30'),
('1', 'Xanis Xan  Has Received Cash  Value: 1', '2023-02-04 18:09:30'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 18:09:30'),
('1', 'Xanis Xan  Has Received Cash  Value: 1', '2023-02-04 18:09:30'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 18:09:30'),
('1', 'Xanis Xan  Has Received Cash  Value: 1', '2023-02-04 18:09:30'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 18:09:31'),
('1', 'Xanis Xan  Has Received Cash  Value: 1', '2023-02-04 18:09:31'),
('2', 'Xanis Xan Aslahe Model Smg Ammo: -4742 Daryaft Kard', '2023-02-04 18:10:36'),
('3', 'Xanis Xan  /getitem 1 1', '2023-02-04 18:13:21'),
('2', 'Xanis Xan  Got Nothing Now: 0', '2023-02-04 18:13:21'),
('3', 'Xanis Xan  se /teleport do: mors', '2023-02-04 18:36:18'),
('3', 'Xanis Xan  se /teleport do: spawn', '2023-02-04 18:36:42'),
('3', 'Xanis Xan  se /teleport do: ei', '2023-02-04 18:37:20'),
('3', 'Xanis Xan  se /teleport do: ph', '2023-02-04 18:40:18'),
('3', 'Xanis Xan  se /teleport do: pb', '2023-02-04 18:40:24'),
('3', 'Xanis Xan  se /teleport do: spawn', '2023-02-04 18:40:28'),
('3', 'Xanis Xan  koristi fly! ', '2023-02-04 18:40:29'),
('3', 'Xanis Xan  koristi fly! ', '2023-02-04 18:40:49'),
('2', 'Xanis Xan Aslahe Model Smg Ammo: -4774 Daryaft Kard', '2023-02-04 18:47:35'),
('3', 'Xanis Xan  /Traje 1', '2023-02-04 18:49:46'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:08'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:08'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:14'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:14'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:15'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:15'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:15'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:15'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:38'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:39'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:39'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:39'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:39'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:39'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:40'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:40'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:40'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:40'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:41'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:41'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:41'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:41'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:42'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:42'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:42'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:42'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:42'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:42'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:43'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:43'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:43'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:43'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:44'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:44'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:44'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:44'),
('3', 'Xanis Xan  je /givemoney igracu: Xanis Xan vrednost: 1', '2023-02-04 22:42:44'),
('1', 'Xanis Xan  Je dobio novac  Kolicina: 1', '2023-02-04 22:42:44'),
('1', 'Hade Fhd  Set Novac na:  Kolicina: 2000', '2023-02-05 13:10:45'),
('1', 'Hade Fhd  Set Novac Na (Banka):  Kolciina: 5000', '2023-02-05 13:10:45'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 2', '2023-02-05 13:36:29'),
('3', 'Hade Fhd  je koristio /setaskin: 808859815', '2023-02-05 16:58:33'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: -323', '2023-02-05 16:59:12'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: -367', '2023-02-05 17:00:34'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: -425', '2023-02-05 17:00:51'),
('3', 'Hade Fhd  je koristio /setaskin: 1318032802', '2023-02-05 17:03:46'),
('3', 'Hade Fhd  je koristio /setaskin: 111281960', '2023-02-05 17:04:55'),
('3', 'Hade Fhd  je koristio /revive na: Hade Fhd', '2023-02-05 17:05:05'),
('3', 'Hade Fhd  je koristio /revive na: Hade Fhd', '2023-02-05 17:05:08'),
('3', 'Hade Fhd  je koristio /revive na: Hade Fhd', '2023-02-05 17:06:39'),
('3', 'Hade Fhd  je koristio /setaskin: 1011059922', '2023-02-05 17:07:12'),
('3', 'Hade Fhd  je koristio /setaskin: 1011059922', '2023-02-05 17:08:15'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 1', '2023-02-05 18:24:13'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 2', '2023-02-05 18:24:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -35', '2023-02-05 18:30:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -1000', '2023-02-05 18:31:25'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 1', '2023-02-05 19:25:49'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 1', '2023-02-05 19:45:27'),
('3', 'Hade Fhd  je postavio dimenziju igracu: Hade Fhd', '2023-02-05 19:54:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -10', '2023-02-05 20:19:34'),
('3', 'Hade Fhd  je /aizbaci  igraca: Hade Fhd ', '2023-02-05 20:30:54'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 4', '2023-02-05 20:31:02'),
('3', 'Hade Fhd  je postavio dimenziju igracu: Hade Fhd', '2023-02-05 20:32:11'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 5', '2023-02-05 20:33:07'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 6', '2023-02-05 20:33:20'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 4', '2023-02-05 20:33:26'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 1 | kolicina:5', '2023-02-05 20:53:08'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 2 | kolicina:5', '2023-02-05 20:53:11'),
('3', 'Hade Fhd  je /givemoney igracu: Hade Fhd vrednost: 250000', '2023-02-05 20:54:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 250000', '2023-02-05 20:54:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -250000', '2023-02-05 20:55:00'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: 250000', '2023-02-05 20:55:01'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: -250000', '2023-02-05 20:55:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 10', '2023-02-06 11:23:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -500', '2023-02-06 11:23:41'),
('3', 'Hade Fhd  popravlja vozilo /fixcar: SA-ADMIN', '2023-02-06 12:59:53'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 1', '2023-02-06 16:38:16'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 4', '2023-02-06 16:40:47'),
('3', 'Hade Fhd /edithouse House_ID: 4 Type: 1', '2023-02-06 16:43:32'),
('3', 'Hade Fhd  je /givemoney igracu: Hade Fhd vrednost: 999999999', '2023-02-06 16:53:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 999999999', '2023-02-06 16:53:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -1000000', '2023-02-06 16:54:23'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: 1000000', '2023-02-06 16:54:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -1000000', '2023-02-06 16:54:24'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: 1000000', '2023-02-06 16:54:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -1000000', '2023-02-06 16:54:25'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: 1000000', '2023-02-06 16:54:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -1000000', '2023-02-06 16:54:25'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: 1000000', '2023-02-06 16:54:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -1000000', '2023-02-06 16:54:25'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: 1000000', '2023-02-06 16:54:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -1000000', '2023-02-06 16:54:26'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: 1000000', '2023-02-06 16:54:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -1000000', '2023-02-06 16:54:26'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: 1000000', '2023-02-06 16:54:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -1000000', '2023-02-06 16:54:26'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: 1000000', '2023-02-06 16:54:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -1000000', '2023-02-06 16:54:26'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: 1000000', '2023-02-06 16:54:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -1000000', '2023-02-06 16:54:27'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: 1000000', '2023-02-06 16:54:27'),
('1', 'Hade Fhd  Je primio novac Banka:  Kolicina: -1460887', '2023-02-06 16:54:41'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 1', '2023-02-06 17:41:44'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 4', '2023-02-06 17:41:49'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 1 | kolicina:5', '2023-02-06 18:22:00'),
('3', 'Hade Fhd  je koristio /ban: Hade Fhd, razlog: test', '2023-02-06 20:33:08'),
('3', 'Hade Fhd  je koristio /ban: Hade Fhd, razlog: test', '2023-02-06 20:41:47'),
('1', 'Hade Fhd  Set Novac na:  Kolicina: 2000', '2023-02-06 23:05:05'),
('1', 'Hade Fhd  Set Novac Na (Banka):  Kolciina: 5000', '2023-02-06 23:05:05'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 9', '2023-02-07 12:56:37'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 8', '2023-02-07 13:10:24'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 9', '2023-02-07 13:28:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -500', '2023-02-07 13:32:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -500', '2023-02-07 13:33:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: -500', '2023-02-07 13:34:07'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 13:48:32'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 4', '2023-02-07 13:50:01'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 9', '2023-02-07 14:08:25'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 4', '2023-02-07 14:19:37'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 8', '2023-02-07 14:28:30'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:4', '2023-02-07 14:56:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 429', '2023-02-07 14:57:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 180', '2023-02-07 14:57:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 158', '2023-02-07 14:57:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 108', '2023-02-07 14:57:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 372', '2023-02-07 14:57:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 418', '2023-02-07 14:57:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 494', '2023-02-07 14:57:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 126', '2023-02-07 14:57:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 383', '2023-02-07 14:57:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 331', '2023-02-07 14:57:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 304', '2023-02-07 14:57:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 125', '2023-02-07 14:57:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 413', '2023-02-07 14:57:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 185', '2023-02-07 14:57:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 425', '2023-02-07 14:57:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 178', '2023-02-07 14:57:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 440', '2023-02-07 14:57:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 313', '2023-02-07 14:57:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 304', '2023-02-07 14:57:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 328', '2023-02-07 14:57:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 203', '2023-02-07 14:57:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 303', '2023-02-07 14:57:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 204', '2023-02-07 14:57:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 415', '2023-02-07 14:57:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 466', '2023-02-07 14:57:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 284', '2023-02-07 14:57:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 234', '2023-02-07 14:57:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 477', '2023-02-07 14:57:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 273', '2023-02-07 14:57:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 336', '2023-02-07 14:57:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 191', '2023-02-07 14:57:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 395', '2023-02-07 14:57:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 279', '2023-02-07 14:57:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 124', '2023-02-07 14:57:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 328', '2023-02-07 14:57:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 497', '2023-02-07 14:58:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 455', '2023-02-07 14:58:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 433', '2023-02-07 14:58:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 390', '2023-02-07 14:58:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 129', '2023-02-07 14:58:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 322', '2023-02-07 14:58:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 167', '2023-02-07 14:58:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 435', '2023-02-07 14:58:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 281', '2023-02-07 14:58:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 101', '2023-02-07 14:58:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 229', '2023-02-07 14:58:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 286', '2023-02-07 14:58:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 232', '2023-02-07 14:58:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 355', '2023-02-07 14:58:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 471', '2023-02-07 14:58:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 286', '2023-02-07 14:58:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 111', '2023-02-07 14:58:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 347', '2023-02-07 14:58:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 280', '2023-02-07 14:58:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 115', '2023-02-07 14:58:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 365', '2023-02-07 14:58:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 133', '2023-02-07 14:58:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 432', '2023-02-07 14:58:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 478', '2023-02-07 14:59:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 174', '2023-02-07 14:59:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 407', '2023-02-07 14:59:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 243', '2023-02-07 14:59:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 437', '2023-02-07 14:59:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 130', '2023-02-07 14:59:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 298', '2023-02-07 14:59:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 236', '2023-02-07 14:59:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 280', '2023-02-07 14:59:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 246', '2023-02-07 14:59:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 318', '2023-02-07 14:59:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 113', '2023-02-07 14:59:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 398', '2023-02-07 14:59:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 313', '2023-02-07 14:59:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 166', '2023-02-07 14:59:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 396', '2023-02-07 14:59:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 456', '2023-02-07 14:59:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 127', '2023-02-07 14:59:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 160', '2023-02-07 14:59:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 124', '2023-02-07 14:59:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 354', '2023-02-07 14:59:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 446', '2023-02-07 14:59:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 339', '2023-02-07 14:59:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 235', '2023-02-07 14:59:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 308', '2023-02-07 14:59:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 255', '2023-02-07 14:59:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 295', '2023-02-07 14:59:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 274', '2023-02-07 14:59:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 321', '2023-02-07 14:59:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 234', '2023-02-07 14:59:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 203', '2023-02-07 14:59:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 121', '2023-02-07 14:59:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 312', '2023-02-07 14:59:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 391', '2023-02-07 14:59:33'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 15:12:39'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-07 15:12:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 241', '2023-02-07 15:14:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 213', '2023-02-07 15:14:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 399', '2023-02-07 15:14:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 377', '2023-02-07 15:14:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 461', '2023-02-07 15:14:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 163', '2023-02-07 15:14:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 496', '2023-02-07 15:14:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 159', '2023-02-07 15:14:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 498', '2023-02-07 15:14:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 133', '2023-02-07 15:14:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 177', '2023-02-07 15:14:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 225', '2023-02-07 15:14:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 222', '2023-02-07 15:14:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 258', '2023-02-07 15:14:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 359', '2023-02-07 15:14:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 197', '2023-02-07 15:14:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 188', '2023-02-07 15:14:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 141', '2023-02-07 15:14:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 234', '2023-02-07 15:14:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 208', '2023-02-07 15:14:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 360', '2023-02-07 15:14:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 381', '2023-02-07 15:14:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 323', '2023-02-07 15:14:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 362', '2023-02-07 15:14:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 185', '2023-02-07 15:14:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 165', '2023-02-07 15:14:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 184', '2023-02-07 15:14:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 120', '2023-02-07 15:14:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 236', '2023-02-07 15:14:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 204', '2023-02-07 15:14:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 465', '2023-02-07 15:14:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 133', '2023-02-07 15:14:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 413', '2023-02-07 15:15:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 297', '2023-02-07 15:15:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 452', '2023-02-07 15:15:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 118', '2023-02-07 15:15:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 474', '2023-02-07 15:15:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 328', '2023-02-07 15:15:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 132', '2023-02-07 15:15:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 345', '2023-02-07 15:15:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 444', '2023-02-07 15:15:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 239', '2023-02-07 15:15:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 208', '2023-02-07 15:15:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 230', '2023-02-07 15:15:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 123', '2023-02-07 15:15:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 121', '2023-02-07 15:15:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 153', '2023-02-07 15:15:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 208', '2023-02-07 15:15:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 455', '2023-02-07 15:15:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 350', '2023-02-07 15:15:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 376', '2023-02-07 15:15:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 201', '2023-02-07 15:15:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 244', '2023-02-07 15:15:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 110', '2023-02-07 15:15:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 443', '2023-02-07 15:15:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 251', '2023-02-07 15:15:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 281', '2023-02-07 15:15:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 427', '2023-02-07 15:15:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 182', '2023-02-07 15:15:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 287', '2023-02-07 15:15:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 369', '2023-02-07 15:15:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 366', '2023-02-07 15:15:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 314', '2023-02-07 15:15:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 283', '2023-02-07 15:15:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 458', '2023-02-07 15:15:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 434', '2023-02-07 15:15:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 202', '2023-02-07 15:15:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 315', '2023-02-07 15:15:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 196', '2023-02-07 15:15:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 231', '2023-02-07 15:15:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 113', '2023-02-07 15:15:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 249', '2023-02-07 15:15:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 398', '2023-02-07 15:15:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 279', '2023-02-07 15:15:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 154', '2023-02-07 15:15:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 110', '2023-02-07 15:15:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 163', '2023-02-07 15:15:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 483', '2023-02-07 15:15:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 229', '2023-02-07 15:15:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 454', '2023-02-07 15:15:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 402', '2023-02-07 15:15:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 365', '2023-02-07 15:15:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 455', '2023-02-07 15:15:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 275', '2023-02-07 15:15:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 219', '2023-02-07 15:15:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 253', '2023-02-07 15:15:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 279', '2023-02-07 15:15:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 293', '2023-02-07 15:15:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 243', '2023-02-07 15:15:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 191', '2023-02-07 15:15:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 227', '2023-02-07 15:15:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 437', '2023-02-07 15:15:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 136', '2023-02-07 15:16:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 235', '2023-02-07 15:16:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 366', '2023-02-07 15:16:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 468', '2023-02-07 15:16:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 316', '2023-02-07 15:16:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 315', '2023-02-07 15:16:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 162', '2023-02-07 15:16:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 479', '2023-02-07 15:16:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 309', '2023-02-07 15:16:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 228', '2023-02-07 15:16:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 402', '2023-02-07 15:16:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 214', '2023-02-07 15:16:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 227', '2023-02-07 15:16:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 116', '2023-02-07 15:16:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 193', '2023-02-07 15:16:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 355', '2023-02-07 15:16:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 345', '2023-02-07 15:16:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 323', '2023-02-07 15:16:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 478', '2023-02-07 15:16:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 188', '2023-02-07 15:16:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 187', '2023-02-07 15:16:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 119', '2023-02-07 15:16:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 275', '2023-02-07 15:16:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 394', '2023-02-07 15:16:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 300', '2023-02-07 15:16:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 428', '2023-02-07 15:16:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 455', '2023-02-07 15:16:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 195', '2023-02-07 15:16:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 145', '2023-02-07 15:16:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 299', '2023-02-07 15:16:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 462', '2023-02-07 15:16:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 396', '2023-02-07 15:16:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 394', '2023-02-07 15:16:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 466', '2023-02-07 15:16:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 103', '2023-02-07 15:16:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 153', '2023-02-07 15:16:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 303', '2023-02-07 15:16:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 476', '2023-02-07 15:16:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 184', '2023-02-07 15:16:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 238', '2023-02-07 15:16:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 311', '2023-02-07 15:16:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 140', '2023-02-07 15:16:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 135', '2023-02-07 15:16:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 165', '2023-02-07 15:16:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 354', '2023-02-07 15:16:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 231', '2023-02-07 15:16:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 438', '2023-02-07 15:16:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 492', '2023-02-07 15:16:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 450', '2023-02-07 15:16:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 314', '2023-02-07 15:16:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 337', '2023-02-07 15:16:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 310', '2023-02-07 15:16:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 103', '2023-02-07 15:16:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 429', '2023-02-07 15:16:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 240', '2023-02-07 15:16:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 407', '2023-02-07 15:16:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 351', '2023-02-07 15:16:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 362', '2023-02-07 15:16:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 158', '2023-02-07 15:16:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 277', '2023-02-07 15:16:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 250', '2023-02-07 15:17:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 356', '2023-02-07 15:17:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 324', '2023-02-07 15:17:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 400', '2023-02-07 15:17:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 156', '2023-02-07 15:17:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 396', '2023-02-07 15:17:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 210', '2023-02-07 15:17:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 151', '2023-02-07 15:17:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 403', '2023-02-07 15:17:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 430', '2023-02-07 15:17:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 442', '2023-02-07 15:17:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 259', '2023-02-07 15:17:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 129', '2023-02-07 15:17:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 230', '2023-02-07 15:17:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 267', '2023-02-07 15:17:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 437', '2023-02-07 15:17:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 374', '2023-02-07 15:17:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 100', '2023-02-07 15:17:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 430', '2023-02-07 15:17:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 459', '2023-02-07 15:17:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 380', '2023-02-07 15:17:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 352', '2023-02-07 15:17:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 135', '2023-02-07 15:17:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 221', '2023-02-07 15:17:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 352', '2023-02-07 15:17:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 142', '2023-02-07 15:17:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 283', '2023-02-07 15:17:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 354', '2023-02-07 15:17:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 216', '2023-02-07 15:17:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 486', '2023-02-07 15:17:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 192', '2023-02-07 15:17:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 331', '2023-02-07 15:17:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 308', '2023-02-07 15:17:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 297', '2023-02-07 15:17:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 378', '2023-02-07 15:17:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 345', '2023-02-07 15:17:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 206', '2023-02-07 15:17:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 125', '2023-02-07 15:17:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 399', '2023-02-07 15:17:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 347', '2023-02-07 15:17:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 411', '2023-02-07 15:17:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 277', '2023-02-07 15:17:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 479', '2023-02-07 15:17:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 410', '2023-02-07 15:17:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 262', '2023-02-07 15:17:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 468', '2023-02-07 15:17:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 171', '2023-02-07 15:17:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 263', '2023-02-07 15:17:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 152', '2023-02-07 15:17:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 193', '2023-02-07 15:17:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 424', '2023-02-07 15:17:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 241', '2023-02-07 15:17:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 322', '2023-02-07 15:17:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 490', '2023-02-07 15:17:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 287', '2023-02-07 15:17:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 288', '2023-02-07 15:17:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 212', '2023-02-07 15:17:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 493', '2023-02-07 15:17:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 438', '2023-02-07 15:17:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 404', '2023-02-07 15:17:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 103', '2023-02-07 15:18:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 246', '2023-02-07 15:18:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 325', '2023-02-07 15:18:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 307', '2023-02-07 15:18:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 228', '2023-02-07 15:18:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 101', '2023-02-07 15:18:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 342', '2023-02-07 15:18:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 222', '2023-02-07 15:18:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 242', '2023-02-07 15:18:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 312', '2023-02-07 15:18:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 221', '2023-02-07 15:18:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 239', '2023-02-07 15:18:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 491', '2023-02-07 15:18:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 473', '2023-02-07 15:18:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 438', '2023-02-07 15:18:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 493', '2023-02-07 15:18:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 263', '2023-02-07 15:18:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 115', '2023-02-07 15:18:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 349', '2023-02-07 15:18:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 274', '2023-02-07 15:18:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 361', '2023-02-07 15:18:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 410', '2023-02-07 15:18:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 192', '2023-02-07 15:18:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 413', '2023-02-07 15:18:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 452', '2023-02-07 15:18:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 341', '2023-02-07 15:18:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 400', '2023-02-07 15:18:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 208', '2023-02-07 15:18:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 400', '2023-02-07 15:18:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 480', '2023-02-07 15:18:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 123', '2023-02-07 15:18:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 103', '2023-02-07 15:18:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 477', '2023-02-07 15:18:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 385', '2023-02-07 15:18:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 234', '2023-02-07 15:18:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 155', '2023-02-07 15:18:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 342', '2023-02-07 15:18:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 162', '2023-02-07 15:18:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 172', '2023-02-07 15:18:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 151', '2023-02-07 15:18:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 116', '2023-02-07 15:18:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 339', '2023-02-07 15:18:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 410', '2023-02-07 15:18:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 230', '2023-02-07 15:18:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 362', '2023-02-07 15:18:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 175', '2023-02-07 15:18:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 139', '2023-02-07 15:18:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 239', '2023-02-07 15:18:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 442', '2023-02-07 15:18:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 184', '2023-02-07 15:18:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 414', '2023-02-07 15:18:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 487', '2023-02-07 15:18:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 133', '2023-02-07 15:18:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 154', '2023-02-07 15:18:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 433', '2023-02-07 15:18:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 483', '2023-02-07 15:18:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 444', '2023-02-07 15:18:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 302', '2023-02-07 15:18:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 245', '2023-02-07 15:18:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 277', '2023-02-07 15:18:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 491', '2023-02-07 15:19:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 124', '2023-02-07 15:19:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 212', '2023-02-07 15:19:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 152', '2023-02-07 15:19:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 179', '2023-02-07 15:19:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 108', '2023-02-07 15:19:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 152', '2023-02-07 15:19:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 496', '2023-02-07 15:19:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 229', '2023-02-07 15:19:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 273', '2023-02-07 15:19:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 141', '2023-02-07 15:19:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 491', '2023-02-07 15:19:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 332', '2023-02-07 15:19:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 188', '2023-02-07 15:19:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 148', '2023-02-07 15:19:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 411', '2023-02-07 15:19:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 390', '2023-02-07 15:19:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 353', '2023-02-07 15:19:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 442', '2023-02-07 15:19:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 268', '2023-02-07 15:19:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 192', '2023-02-07 15:19:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 151', '2023-02-07 15:19:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 156', '2023-02-07 15:19:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 206', '2023-02-07 15:19:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 456', '2023-02-07 15:19:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 426', '2023-02-07 15:19:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 360', '2023-02-07 15:19:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 314', '2023-02-07 15:19:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 342', '2023-02-07 15:19:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 141', '2023-02-07 15:19:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 101', '2023-02-07 15:19:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 431', '2023-02-07 15:19:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 307', '2023-02-07 15:19:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 286', '2023-02-07 15:19:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 450', '2023-02-07 15:19:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 382', '2023-02-07 15:19:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 117', '2023-02-07 15:19:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 248', '2023-02-07 15:19:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 441', '2023-02-07 15:19:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 244', '2023-02-07 15:19:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 413', '2023-02-07 15:19:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 433', '2023-02-07 15:19:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 400', '2023-02-07 15:19:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 159', '2023-02-07 15:19:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 432', '2023-02-07 15:19:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 313', '2023-02-07 15:19:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 145', '2023-02-07 15:19:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 335', '2023-02-07 15:19:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 395', '2023-02-07 15:19:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 412', '2023-02-07 15:19:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 483', '2023-02-07 15:19:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 481', '2023-02-07 15:19:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 250', '2023-02-07 15:19:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 367', '2023-02-07 15:19:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 475', '2023-02-07 15:19:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 330', '2023-02-07 15:19:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 358', '2023-02-07 15:19:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 396', '2023-02-07 15:19:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 486', '2023-02-07 15:19:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 143', '2023-02-07 15:19:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 138', '2023-02-07 15:20:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 228', '2023-02-07 15:20:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 144', '2023-02-07 15:20:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 477', '2023-02-07 15:20:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 162', '2023-02-07 15:20:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 101', '2023-02-07 15:20:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 174', '2023-02-07 15:20:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 437', '2023-02-07 15:20:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 128', '2023-02-07 15:20:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 156', '2023-02-07 15:20:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 284', '2023-02-07 15:20:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 132', '2023-02-07 15:20:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 302', '2023-02-07 15:20:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 188', '2023-02-07 15:20:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 244', '2023-02-07 15:20:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 149', '2023-02-07 15:20:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 140', '2023-02-07 15:20:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 387', '2023-02-07 15:20:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 164', '2023-02-07 15:20:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 132', '2023-02-07 15:20:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 271', '2023-02-07 15:20:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 414', '2023-02-07 15:20:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 308', '2023-02-07 15:20:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 320', '2023-02-07 15:20:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 448', '2023-02-07 15:20:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 410', '2023-02-07 15:20:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 171', '2023-02-07 15:20:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 331', '2023-02-07 15:20:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 201', '2023-02-07 15:20:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 110', '2023-02-07 15:20:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 414', '2023-02-07 15:20:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 112', '2023-02-07 15:20:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 152', '2023-02-07 15:20:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 287', '2023-02-07 15:20:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 495', '2023-02-07 15:20:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 175', '2023-02-07 15:20:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 279', '2023-02-07 15:20:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 313', '2023-02-07 15:20:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 387', '2023-02-07 15:20:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 322', '2023-02-07 15:20:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 130', '2023-02-07 15:20:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 498', '2023-02-07 15:20:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 198', '2023-02-07 15:20:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 229', '2023-02-07 15:20:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 118', '2023-02-07 15:20:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 341', '2023-02-07 15:20:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 169', '2023-02-07 15:20:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 452', '2023-02-07 15:20:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 113', '2023-02-07 15:20:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 316', '2023-02-07 15:20:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 180', '2023-02-07 15:20:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 361', '2023-02-07 15:20:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 222', '2023-02-07 15:20:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 344', '2023-02-07 15:20:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 262', '2023-02-07 15:20:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 114', '2023-02-07 15:20:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 309', '2023-02-07 15:20:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 214', '2023-02-07 15:20:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 419', '2023-02-07 15:20:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 141', '2023-02-07 15:20:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 320', '2023-02-07 15:21:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 233', '2023-02-07 15:21:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 226', '2023-02-07 15:21:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 408', '2023-02-07 15:21:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 132', '2023-02-07 15:21:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 163', '2023-02-07 15:21:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 370', '2023-02-07 15:21:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 405', '2023-02-07 15:21:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 482', '2023-02-07 15:21:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 459', '2023-02-07 15:21:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 260', '2023-02-07 15:21:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 217', '2023-02-07 15:21:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 390', '2023-02-07 15:21:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 232', '2023-02-07 15:21:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 393', '2023-02-07 15:21:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 163', '2023-02-07 15:21:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 207', '2023-02-07 15:21:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 469', '2023-02-07 15:21:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 192', '2023-02-07 15:21:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 497', '2023-02-07 15:21:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 231', '2023-02-07 15:21:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 108', '2023-02-07 15:21:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 208', '2023-02-07 15:21:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 275', '2023-02-07 15:21:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 320', '2023-02-07 15:21:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 443', '2023-02-07 15:21:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 280', '2023-02-07 15:21:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 197', '2023-02-07 15:21:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 415', '2023-02-07 15:21:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 371', '2023-02-07 15:21:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 256', '2023-02-07 15:21:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 455', '2023-02-07 15:21:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 284', '2023-02-07 15:21:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 236', '2023-02-07 15:21:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 392', '2023-02-07 15:21:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 287', '2023-02-07 15:21:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 262', '2023-02-07 15:21:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 180', '2023-02-07 15:21:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 487', '2023-02-07 15:21:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 345', '2023-02-07 15:21:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 361', '2023-02-07 15:21:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 154', '2023-02-07 15:21:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 360', '2023-02-07 15:21:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 444', '2023-02-07 15:21:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 446', '2023-02-07 15:21:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 353', '2023-02-07 15:21:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 361', '2023-02-07 15:21:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 380', '2023-02-07 15:21:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 342', '2023-02-07 15:21:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 490', '2023-02-07 15:21:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 297', '2023-02-07 15:21:50');
INSERT INTO `server_log` (`log_type`, `log_message`, `log_time`) VALUES
('1', 'Hade Fhd  Je dobio novac  Kolicina: 230', '2023-02-07 15:21:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 412', '2023-02-07 15:21:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 312', '2023-02-07 15:21:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 300', '2023-02-07 15:21:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 202', '2023-02-07 15:21:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 415', '2023-02-07 15:21:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 341', '2023-02-07 15:21:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 478', '2023-02-07 15:21:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 479', '2023-02-07 15:21:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 273', '2023-02-07 15:22:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 163', '2023-02-07 15:22:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 380', '2023-02-07 15:22:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 101', '2023-02-07 15:22:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 193', '2023-02-07 15:22:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 195', '2023-02-07 15:22:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 323', '2023-02-07 15:22:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 144', '2023-02-07 15:22:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 230', '2023-02-07 15:22:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 496', '2023-02-07 15:22:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 290', '2023-02-07 15:22:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 417', '2023-02-07 15:22:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 372', '2023-02-07 15:22:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 237', '2023-02-07 15:22:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 126', '2023-02-07 15:22:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 467', '2023-02-07 15:22:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 138', '2023-02-07 15:22:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 154', '2023-02-07 15:22:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 218', '2023-02-07 15:22:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 356', '2023-02-07 15:22:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 472', '2023-02-07 15:22:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 290', '2023-02-07 15:22:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 246', '2023-02-07 15:22:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 315', '2023-02-07 15:22:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 464', '2023-02-07 15:22:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 416', '2023-02-07 15:22:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 433', '2023-02-07 15:22:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 363', '2023-02-07 15:22:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 326', '2023-02-07 15:22:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 180', '2023-02-07 15:22:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 262', '2023-02-07 15:22:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 311', '2023-02-07 15:22:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 492', '2023-02-07 15:22:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 398', '2023-02-07 15:22:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 462', '2023-02-07 15:22:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 188', '2023-02-07 15:22:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 164', '2023-02-07 15:22:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 249', '2023-02-07 15:22:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 240', '2023-02-07 15:22:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 241', '2023-02-07 15:22:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 421', '2023-02-07 15:22:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 208', '2023-02-07 15:22:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 140', '2023-02-07 15:22:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 236', '2023-02-07 15:22:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 189', '2023-02-07 15:22:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 270', '2023-02-07 15:22:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 248', '2023-02-07 15:22:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 164', '2023-02-07 15:22:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 175', '2023-02-07 15:22:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 223', '2023-02-07 15:22:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 453', '2023-02-07 15:23:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 251', '2023-02-07 15:23:04'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 1', '2023-02-07 15:23:40'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 8', '2023-02-07 15:47:29'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 15:48:07'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-07 15:48:09'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 15:53:58'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 15:56:47'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 16:09:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 389', '2023-02-07 16:12:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 396', '2023-02-07 16:12:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 269', '2023-02-07 16:12:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 447', '2023-02-07 16:12:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 159', '2023-02-07 16:12:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 496', '2023-02-07 16:12:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 107', '2023-02-07 16:12:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 251', '2023-02-07 16:12:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 323', '2023-02-07 16:12:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 101', '2023-02-07 16:12:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 129', '2023-02-07 16:12:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 375', '2023-02-07 16:12:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 302', '2023-02-07 16:12:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 309', '2023-02-07 16:12:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 344', '2023-02-07 16:12:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 250', '2023-02-07 16:12:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 365', '2023-02-07 16:12:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 420', '2023-02-07 16:12:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 462', '2023-02-07 16:12:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 168', '2023-02-07 16:12:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 257', '2023-02-07 16:12:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 466', '2023-02-07 16:12:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 166', '2023-02-07 16:12:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 455', '2023-02-07 16:12:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 183', '2023-02-07 16:12:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 382', '2023-02-07 16:12:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 338', '2023-02-07 16:12:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 382', '2023-02-07 16:12:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 286', '2023-02-07 16:12:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 336', '2023-02-07 16:12:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 348', '2023-02-07 16:12:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 165', '2023-02-07 16:12:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 465', '2023-02-07 16:12:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 338', '2023-02-07 16:12:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 472', '2023-02-07 16:12:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 491', '2023-02-07 16:12:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 425', '2023-02-07 16:12:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 110', '2023-02-07 16:12:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 452', '2023-02-07 16:12:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 496', '2023-02-07 16:12:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 323', '2023-02-07 16:12:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 449', '2023-02-07 16:12:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 405', '2023-02-07 16:12:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 181', '2023-02-07 16:12:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 192', '2023-02-07 16:13:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 159', '2023-02-07 16:13:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 459', '2023-02-07 16:13:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 151', '2023-02-07 16:13:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 492', '2023-02-07 16:13:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 224', '2023-02-07 16:13:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 154', '2023-02-07 16:13:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 491', '2023-02-07 16:13:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 432', '2023-02-07 16:13:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 443', '2023-02-07 16:13:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 263', '2023-02-07 16:13:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 313', '2023-02-07 16:13:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 220', '2023-02-07 16:13:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 203', '2023-02-07 16:13:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 254', '2023-02-07 16:13:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 167', '2023-02-07 16:13:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 148', '2023-02-07 16:13:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 115', '2023-02-07 16:13:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 355', '2023-02-07 16:13:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 377', '2023-02-07 16:13:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 143', '2023-02-07 16:13:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 354', '2023-02-07 16:13:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 300', '2023-02-07 16:13:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 354', '2023-02-07 16:13:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 227', '2023-02-07 16:13:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 242', '2023-02-07 16:13:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 215', '2023-02-07 16:13:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 245', '2023-02-07 16:13:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 358', '2023-02-07 16:13:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 356', '2023-02-07 16:13:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 235', '2023-02-07 16:13:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 198', '2023-02-07 16:13:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 452', '2023-02-07 16:13:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 374', '2023-02-07 16:13:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 254', '2023-02-07 16:13:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 414', '2023-02-07 16:13:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 314', '2023-02-07 16:13:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 176', '2023-02-07 16:13:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 280', '2023-02-07 16:13:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 452', '2023-02-07 16:13:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 172', '2023-02-07 16:13:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 247', '2023-02-07 16:13:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 122', '2023-02-07 16:13:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 412', '2023-02-07 16:13:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 465', '2023-02-07 16:13:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 149', '2023-02-07 16:13:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 262', '2023-02-07 16:13:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 212', '2023-02-07 16:13:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 246', '2023-02-07 16:13:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 275', '2023-02-07 16:13:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 338', '2023-02-07 16:13:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 198', '2023-02-07 16:13:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 484', '2023-02-07 16:13:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 418', '2023-02-07 16:13:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 429', '2023-02-07 16:13:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 228', '2023-02-07 16:13:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 249', '2023-02-07 16:13:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 494', '2023-02-07 16:13:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 314', '2023-02-07 16:13:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 240', '2023-02-07 16:13:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 399', '2023-02-07 16:14:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 299', '2023-02-07 16:14:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 124', '2023-02-07 16:14:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 466', '2023-02-07 16:14:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 198', '2023-02-07 16:14:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 455', '2023-02-07 16:14:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 251', '2023-02-07 16:14:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 235', '2023-02-07 16:14:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 340', '2023-02-07 16:14:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 230', '2023-02-07 16:14:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 243', '2023-02-07 16:14:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 361', '2023-02-07 16:14:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 226', '2023-02-07 16:14:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 293', '2023-02-07 16:14:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 195', '2023-02-07 16:14:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 286', '2023-02-07 16:14:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 222', '2023-02-07 16:14:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 278', '2023-02-07 16:14:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 279', '2023-02-07 16:14:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 468', '2023-02-07 16:14:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 371', '2023-02-07 16:14:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 393', '2023-02-07 16:14:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 389', '2023-02-07 16:14:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 472', '2023-02-07 16:14:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 408', '2023-02-07 16:14:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 427', '2023-02-07 16:14:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 104', '2023-02-07 16:14:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 424', '2023-02-07 16:14:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 336', '2023-02-07 16:14:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 416', '2023-02-07 16:14:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 155', '2023-02-07 16:14:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 209', '2023-02-07 16:14:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 252', '2023-02-07 16:14:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 430', '2023-02-07 16:14:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 443', '2023-02-07 16:14:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 262', '2023-02-07 16:14:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 113', '2023-02-07 16:14:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 446', '2023-02-07 16:14:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 203', '2023-02-07 16:14:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 400', '2023-02-07 16:14:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 288', '2023-02-07 16:14:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 416', '2023-02-07 16:14:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 263', '2023-02-07 16:14:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 406', '2023-02-07 16:14:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 422', '2023-02-07 16:14:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 367', '2023-02-07 16:14:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 362', '2023-02-07 16:14:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 181', '2023-02-07 16:14:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 212', '2023-02-07 16:14:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 133', '2023-02-07 16:14:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 396', '2023-02-07 16:14:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 361', '2023-02-07 16:14:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 205', '2023-02-07 16:14:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 236', '2023-02-07 16:14:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 259', '2023-02-07 16:14:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 396', '2023-02-07 16:14:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 300', '2023-02-07 16:14:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 442', '2023-02-07 16:14:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 448', '2023-02-07 16:14:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 161', '2023-02-07 16:14:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 341', '2023-02-07 16:15:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 217', '2023-02-07 16:15:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 290', '2023-02-07 16:15:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 313', '2023-02-07 16:15:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 465', '2023-02-07 16:15:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 423', '2023-02-07 16:15:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 499', '2023-02-07 16:15:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 186', '2023-02-07 16:15:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 240', '2023-02-07 16:15:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 323', '2023-02-07 16:15:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 163', '2023-02-07 16:15:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 166', '2023-02-07 16:15:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 465', '2023-02-07 16:15:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 270', '2023-02-07 16:15:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 170', '2023-02-07 16:15:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 345', '2023-02-07 16:15:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 120', '2023-02-07 16:15:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 373', '2023-02-07 16:15:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 440', '2023-02-07 16:15:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 432', '2023-02-07 16:15:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 455', '2023-02-07 16:15:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 313', '2023-02-07 16:15:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 202', '2023-02-07 16:15:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 193', '2023-02-07 16:15:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 410', '2023-02-07 16:15:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 184', '2023-02-07 16:15:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 394', '2023-02-07 16:15:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 407', '2023-02-07 16:15:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 161', '2023-02-07 16:15:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 437', '2023-02-07 16:15:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 352', '2023-02-07 16:15:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 461', '2023-02-07 16:15:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 388', '2023-02-07 16:15:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 432', '2023-02-07 16:15:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 448', '2023-02-07 16:15:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 461', '2023-02-07 16:15:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 116', '2023-02-07 16:15:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 339', '2023-02-07 16:15:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 332', '2023-02-07 16:15:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 389', '2023-02-07 16:15:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 258', '2023-02-07 16:15:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 166', '2023-02-07 16:15:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 331', '2023-02-07 16:15:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 279', '2023-02-07 16:15:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 360', '2023-02-07 16:15:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 220', '2023-02-07 16:15:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 286', '2023-02-07 16:15:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 326', '2023-02-07 16:15:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 455', '2023-02-07 16:15:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 304', '2023-02-07 16:15:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 266', '2023-02-07 16:15:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 317', '2023-02-07 16:15:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 392', '2023-02-07 16:15:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 406', '2023-02-07 16:15:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 497', '2023-02-07 16:15:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 419', '2023-02-07 16:15:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 405', '2023-02-07 16:15:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 487', '2023-02-07 16:15:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 293', '2023-02-07 16:15:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 270', '2023-02-07 16:15:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 419', '2023-02-07 16:16:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 482', '2023-02-07 16:16:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 415', '2023-02-07 16:16:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 192', '2023-02-07 16:16:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 361', '2023-02-07 16:16:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 492', '2023-02-07 16:16:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 167', '2023-02-07 16:16:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 423', '2023-02-07 16:16:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 211', '2023-02-07 16:16:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 100', '2023-02-07 16:16:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 218', '2023-02-07 16:16:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 171', '2023-02-07 16:16:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 431', '2023-02-07 16:16:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 441', '2023-02-07 16:16:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 164', '2023-02-07 16:16:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 278', '2023-02-07 16:16:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 371', '2023-02-07 16:16:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 313', '2023-02-07 16:16:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 223', '2023-02-07 16:16:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 180', '2023-02-07 16:16:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 289', '2023-02-07 16:16:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 459', '2023-02-07 16:16:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 342', '2023-02-07 16:16:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 246', '2023-02-07 16:16:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 162', '2023-02-07 16:16:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 425', '2023-02-07 16:16:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 460', '2023-02-07 16:16:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 372', '2023-02-07 16:16:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 325', '2023-02-07 16:16:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 420', '2023-02-07 16:16:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 445', '2023-02-07 16:16:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 419', '2023-02-07 16:16:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 436', '2023-02-07 16:16:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 451', '2023-02-07 16:16:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 360', '2023-02-07 16:16:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 166', '2023-02-07 16:16:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 142', '2023-02-07 16:16:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 129', '2023-02-07 16:16:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 308', '2023-02-07 16:16:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 258', '2023-02-07 16:16:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 443', '2023-02-07 16:16:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 253', '2023-02-07 16:16:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 104', '2023-02-07 16:16:42'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 345', '2023-02-07 16:16:43'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 476', '2023-02-07 16:16:44'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 485', '2023-02-07 16:16:45'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 276', '2023-02-07 16:16:46'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 341', '2023-02-07 16:16:47'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 232', '2023-02-07 16:16:48'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 209', '2023-02-07 16:16:49'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 437', '2023-02-07 16:16:50'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 483', '2023-02-07 16:16:51'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 254', '2023-02-07 16:16:52'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 103', '2023-02-07 16:16:53'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 372', '2023-02-07 16:16:54'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 351', '2023-02-07 16:16:55'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 130', '2023-02-07 16:16:56'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 158', '2023-02-07 16:16:57'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 420', '2023-02-07 16:16:58'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 326', '2023-02-07 16:16:59'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 422', '2023-02-07 16:17:00'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 186', '2023-02-07 16:17:01'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 488', '2023-02-07 16:17:02'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 182', '2023-02-07 16:17:03'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 445', '2023-02-07 16:17:04'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 189', '2023-02-07 16:17:05'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 125', '2023-02-07 16:17:06'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 370', '2023-02-07 16:17:07'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 471', '2023-02-07 16:17:08'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 388', '2023-02-07 16:17:09'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 127', '2023-02-07 16:17:10'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 232', '2023-02-07 16:17:11'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 394', '2023-02-07 16:17:12'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 354', '2023-02-07 16:17:13'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 127', '2023-02-07 16:17:14'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 426', '2023-02-07 16:17:15'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 344', '2023-02-07 16:17:16'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 386', '2023-02-07 16:17:17'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 160', '2023-02-07 16:17:18'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 467', '2023-02-07 16:17:19'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 139', '2023-02-07 16:17:20'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 108', '2023-02-07 16:17:21'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 130', '2023-02-07 16:17:22'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 107', '2023-02-07 16:17:23'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 372', '2023-02-07 16:17:24'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 352', '2023-02-07 16:17:25'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 155', '2023-02-07 16:17:26'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 323', '2023-02-07 16:17:27'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 469', '2023-02-07 16:17:28'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 399', '2023-02-07 16:17:29'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 425', '2023-02-07 16:17:30'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 373', '2023-02-07 16:17:31'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 499', '2023-02-07 16:17:32'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 372', '2023-02-07 16:17:33'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 226', '2023-02-07 16:17:34'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 247', '2023-02-07 16:17:35'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 155', '2023-02-07 16:17:36'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 313', '2023-02-07 16:17:37'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 291', '2023-02-07 16:17:38'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 277', '2023-02-07 16:17:39'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 349', '2023-02-07 16:17:40'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 296', '2023-02-07 16:17:41'),
('1', 'Hade Fhd  Je dobio novac  Kolicina: 260', '2023-02-07 16:17:42'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 1', '2023-02-07 16:17:54'),
('3', 'Hade Fhd  je /setleader igracu: Hade Fhd organizacije: 8', '2023-02-07 16:21:30'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 16:21:41'),
('3', 'Hade Fhd je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-07 16:21:46'),
('1', 'Test Tests  Set Novac na:  Kolicina: 2000', '2023-02-07 18:25:50'),
('1', 'Test Tests  Set Novac Na (Banka):  Kolciina: 5000', '2023-02-07 18:25:50'),
('3', 'Test Tests  je /setxp igracu: Test Tests na: 1', '2023-02-07 19:04:39'),
('3', 'Test Tests  je /setskill igracu Test Tests vrednost: 100', '2023-02-07 19:05:30'),
('3', 'Test Tests  je /setskill igracu Test Tests vrednost: 99', '2023-02-07 19:06:04'),
('3', 'Test Tests je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-07 19:09:24'),
('3', 'Test Tests je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 19:09:25'),
('1', 'Test Test  Set Novac na:  Kolicina: 2000', '2023-02-07 20:29:56'),
('1', 'Test Test  Set Novac Na (Banka):  Kolciina: 5000', '2023-02-07 20:29:57'),
('1', 'Test Test  Set Novac na:  Kolicina: 2000', '2023-02-07 21:00:39'),
('1', 'Test Test  Set Novac Na (Banka):  Kolciina: 5000', '2023-02-07 21:00:39'),
('1', 'Test Test  Set Novac na:  Kolicina: 2000', '2023-02-07 21:07:05'),
('1', 'Test Test  Set Novac Na (Banka):  Kolciina: 5000', '2023-02-07 21:07:05'),
('1', 'Test Test  Set Novac na:  Kolicina: 2000', '2023-02-07 21:28:13'),
('1', 'Test Test  Set Novac Na (Banka):  Kolciina: 5000', '2023-02-07 21:28:13'),
('1', 'Test Test  Je dobio novac  Kolicina: -750', '2023-02-07 21:36:30'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-07 21:51:44'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 21:51:47'),
('1', 'Test Test  Je dobio novac  Kolicina: 444', '2023-02-07 21:53:45'),
('1', 'Test Test  Je dobio novac  Kolicina: 195', '2023-02-07 21:53:46'),
('1', 'Test Test  Je dobio novac  Kolicina: 144', '2023-02-07 21:53:47'),
('1', 'Test Test  Je dobio novac  Kolicina: 250', '2023-02-07 21:53:49'),
('1', 'Test Test  Je dobio novac  Kolicina: 317', '2023-02-07 21:53:54'),
('1', 'Test Test  Je dobio novac  Kolicina: 121', '2023-02-07 21:53:55'),
('1', 'Test Test  Je dobio novac  Kolicina: 296', '2023-02-07 21:53:56'),
('1', 'Test Test  Je dobio novac  Kolicina: 338', '2023-02-07 21:53:57'),
('1', 'Test Test  Je dobio novac  Kolicina: 223', '2023-02-07 21:53:58'),
('1', 'Test Test  Je dobio novac  Kolicina: 463', '2023-02-07 21:53:59'),
('1', 'Test Test  Je dobio novac  Kolicina: 185', '2023-02-07 21:54:00'),
('1', 'Test Test  Je dobio novac  Kolicina: 461', '2023-02-07 21:54:01'),
('1', 'Test Test  Je dobio novac  Kolicina: 340', '2023-02-07 21:54:08'),
('1', 'Test Test  Je dobio novac  Kolicina: 464', '2023-02-07 21:54:09'),
('1', 'Test Test  Je dobio novac  Kolicina: 492', '2023-02-07 21:54:10'),
('1', 'Test Test  Je dobio novac  Kolicina: 168', '2023-02-07 21:54:11'),
('1', 'Test Test  Je dobio novac  Kolicina: 118', '2023-02-07 21:54:12'),
('1', 'Test Test  Je dobio novac  Kolicina: 177', '2023-02-07 21:54:13'),
('1', 'Test Test  Je dobio novac  Kolicina: 297', '2023-02-07 21:54:14'),
('1', 'Test Test  Je dobio novac  Kolicina: 338', '2023-02-07 21:54:15'),
('1', 'Test Test  Je dobio novac  Kolicina: 129', '2023-02-07 21:54:16'),
('1', 'Test Test  Je dobio novac  Kolicina: 451', '2023-02-07 21:54:17'),
('1', 'Test Test  Je dobio novac  Kolicina: 138', '2023-02-07 21:54:18'),
('1', 'Test Test  Je dobio novac  Kolicina: 423', '2023-02-07 21:54:19'),
('1', 'Test Test  Je dobio novac  Kolicina: 326', '2023-02-07 21:54:20'),
('1', 'Test Test  Je dobio novac  Kolicina: 258', '2023-02-07 21:55:46'),
('1', 'Test Test  Je dobio novac  Kolicina: 464', '2023-02-07 21:55:47'),
('1', 'Test Test  Je dobio novac  Kolicina: 214', '2023-02-07 21:55:48'),
('1', 'Test Test  Je dobio novac  Kolicina: 312', '2023-02-07 21:55:49'),
('1', 'Test Test  Je dobio novac  Kolicina: 158', '2023-02-07 21:55:50'),
('1', 'Test Test  Je dobio novac  Kolicina: 178', '2023-02-07 21:56:25'),
('1', 'Test Test  Je dobio novac  Kolicina: 274', '2023-02-07 21:56:26'),
('1', 'Test Test  Je dobio novac  Kolicina: 486', '2023-02-07 21:56:27'),
('1', 'Test Test  Je dobio novac  Kolicina: 279', '2023-02-07 21:56:29'),
('1', 'Test Test  Je dobio novac  Kolicina: 443', '2023-02-07 21:56:30'),
('1', 'Test Test  Je dobio novac  Kolicina: 267', '2023-02-07 21:56:31'),
('1', 'Test Test  Je dobio novac  Kolicina: 215', '2023-02-07 21:56:34'),
('1', 'Test Test  Je dobio novac  Kolicina: 247', '2023-02-07 21:56:35'),
('1', 'Test Test  Je dobio novac  Kolicina: 250', '2023-02-07 21:56:36'),
('1', 'Test Test  Je dobio novac  Kolicina: 197', '2023-02-07 21:56:45'),
('1', 'Test Test  Je dobio novac  Kolicina: 481', '2023-02-07 21:56:46'),
('1', 'Test Test  Je dobio novac  Kolicina: 284', '2023-02-07 21:56:47'),
('1', 'Test Test  Je dobio novac  Kolicina: 195', '2023-02-07 21:56:48'),
('3', 'Test Test  je /setxp igracu: Test Test na: 150', '2023-02-07 21:58:55'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-07 22:02:45'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 22:02:46'),
('1', 'Test Test  Je dobio novac  Kolicina: 360', '2023-02-07 22:17:12'),
('1', 'Test Test  Je dobio novac  Kolicina: 369', '2023-02-07 22:17:13'),
('1', 'Test Test  Je dobio novac  Kolicina: 103', '2023-02-07 22:17:14'),
('1', 'Test Test  Je dobio novac  Kolicina: 306', '2023-02-07 22:17:15'),
('1', 'Test Test  Je dobio novac  Kolicina: 306', '2023-02-07 22:17:16'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-07 22:40:12'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 22:40:14'),
('3', 'Test Test  je /setleader igracu: Test Test organizacije: 8', '2023-02-07 22:47:17'),
('3', 'Test Test  je /setskill igracu Test Test vrednost: 150', '2023-02-07 22:51:48'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: 0', '2023-02-07 23:38:14'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: 0', '2023-02-07 23:38:14'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 23:45:49'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-07 23:45:52'),
('1', 'Test Test  Je dobio novac  Kolicina: 313', '2023-02-07 23:47:30'),
('1', 'Test Test  Je dobio novac  Kolicina: 400', '2023-02-07 23:47:31'),
('1', 'Test Test  Je dobio novac  Kolicina: 300', '2023-02-07 23:47:32'),
('1', 'Test Test  Je dobio novac  Kolicina: 201', '2023-02-07 23:47:33'),
('1', 'Test Test  Je dobio novac  Kolicina: 335', '2023-02-07 23:47:34'),
('1', 'Test Test  Je dobio novac  Kolicina: 349', '2023-02-07 23:47:35'),
('1', 'Test Test  Je dobio novac  Kolicina: 408', '2023-02-07 23:47:36'),
('1', 'Test Test  Je dobio novac  Kolicina: 238', '2023-02-07 23:47:37'),
('1', 'Test Test  Je dobio novac  Kolicina: 230', '2023-02-07 23:47:38'),
('1', 'Test Test  Je dobio novac  Kolicina: 142', '2023-02-07 23:47:39'),
('1', 'Test Test  Je dobio novac  Kolicina: 163', '2023-02-07 23:47:40'),
('1', 'Test Test  Je dobio novac  Kolicina: 467', '2023-02-07 23:47:41'),
('1', 'Test Test  Je dobio novac  Kolicina: 192', '2023-02-07 23:47:42'),
('1', 'Test Test  Je dobio novac  Kolicina: 125', '2023-02-07 23:47:43'),
('1', 'Test Test  Je dobio novac  Kolicina: 423', '2023-02-07 23:47:44'),
('1', 'Test Test  Je dobio novac  Kolicina: 187', '2023-02-07 23:47:45'),
('1', 'Test Test  Je dobio novac  Kolicina: 375', '2023-02-07 23:47:46'),
('1', 'Test Test  Je dobio novac  Kolicina: 318', '2023-02-07 23:47:47'),
('1', 'Test Test  Je dobio novac  Kolicina: 467', '2023-02-07 23:47:48'),
('1', 'Test Test  Je dobio novac  Kolicina: 148', '2023-02-07 23:47:49'),
('1', 'Test Test  Je dobio novac  Kolicina: 321', '2023-02-07 23:47:50'),
('1', 'Test Test  Je dobio novac  Kolicina: 408', '2023-02-07 23:47:51'),
('1', 'Test Test  Je dobio novac  Kolicina: 124', '2023-02-07 23:47:52'),
('1', 'Test Test  Je dobio novac  Kolicina: 434', '2023-02-07 23:47:53'),
('1', 'Test Test  Je dobio novac  Kolicina: 436', '2023-02-07 23:47:54'),
('1', 'Test Test  Je dobio novac  Kolicina: 369', '2023-02-07 23:47:55'),
('1', 'Test Test  Je dobio novac  Kolicina: 225', '2023-02-07 23:47:56'),
('1', 'Test Test  Je dobio novac  Kolicina: 426', '2023-02-07 23:47:57'),
('1', 'Test Test  Je dobio novac  Kolicina: 173', '2023-02-07 23:47:58'),
('1', 'Test Test  Je dobio novac  Kolicina: 169', '2023-02-07 23:47:59'),
('1', 'Test Test  Je dobio novac  Kolicina: 467', '2023-02-07 23:48:00'),
('1', 'Test Test  Je dobio novac  Kolicina: 216', '2023-02-07 23:48:01'),
('1', 'Test Test  Je dobio novac  Kolicina: 425', '2023-02-07 23:48:02'),
('1', 'Test Test  Je dobio novac  Kolicina: 307', '2023-02-07 23:48:03'),
('1', 'Test Test  Je dobio novac  Kolicina: 452', '2023-02-07 23:48:04'),
('1', 'Test Test  Je dobio novac  Kolicina: 254', '2023-02-07 23:48:05'),
('1', 'Test Test  Je dobio novac  Kolicina: 481', '2023-02-07 23:48:06'),
('1', 'Test Test  Je dobio novac  Kolicina: 209', '2023-02-07 23:48:07'),
('1', 'Test Test  Je dobio novac  Kolicina: 456', '2023-02-07 23:48:08'),
('1', 'Test Test  Je dobio novac  Kolicina: 237', '2023-02-07 23:48:09'),
('1', 'Test Test  Je dobio novac  Kolicina: 232', '2023-02-07 23:48:10'),
('1', 'Test Test  Je dobio novac  Kolicina: 233', '2023-02-07 23:48:11'),
('1', 'Test Test  Je dobio novac  Kolicina: 485', '2023-02-07 23:48:12'),
('1', 'Test Test  Je dobio novac  Kolicina: 198', '2023-02-07 23:48:13'),
('1', 'Test Test  Je dobio novac  Kolicina: 183', '2023-02-07 23:48:14'),
('1', 'Test Test  Je dobio novac  Kolicina: 467', '2023-02-07 23:48:15'),
('1', 'Test Test  Je dobio novac  Kolicina: 474', '2023-02-07 23:48:16'),
('1', 'Test Test  Je dobio novac  Kolicina: 139', '2023-02-07 23:48:17'),
('1', 'Test Test  Je dobio novac  Kolicina: 173', '2023-02-07 23:48:18'),
('1', 'Test Test  Je dobio novac  Kolicina: 409', '2023-02-07 23:48:19'),
('1', 'Test Test  Je dobio novac  Kolicina: 417', '2023-02-07 23:48:20'),
('1', 'Test Test  Je dobio novac  Kolicina: 491', '2023-02-07 23:48:21'),
('1', 'Test Test  Je dobio novac  Kolicina: 301', '2023-02-07 23:48:22'),
('1', 'Test Test  Je dobio novac  Kolicina: 144', '2023-02-07 23:48:23'),
('1', 'Test Test  Je dobio novac  Kolicina: 461', '2023-02-07 23:48:24'),
('1', 'Test Test  Je dobio novac  Kolicina: 295', '2023-02-07 23:48:25'),
('1', 'Test Test  Je dobio novac  Kolicina: 266', '2023-02-07 23:48:26'),
('1', 'Test Test  Je dobio novac  Kolicina: 255', '2023-02-07 23:48:27'),
('1', 'Test Test  Je dobio novac  Kolicina: 155', '2023-02-07 23:48:28'),
('1', 'Test Test  Je dobio novac  Kolicina: 356', '2023-02-07 23:48:29'),
('1', 'Test Test  Je dobio novac  Kolicina: 113', '2023-02-07 23:48:30'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-07 23:52:16'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 23:52:18'),
('1', 'Test Test  Je dobio novac  Kolicina: 253', '2023-02-07 23:54:01'),
('1', 'Test Test  Je dobio novac  Kolicina: 401', '2023-02-07 23:54:02'),
('1', 'Test Test  Je dobio novac  Kolicina: 146', '2023-02-07 23:54:03'),
('1', 'Test Test  Je dobio novac  Kolicina: 224', '2023-02-07 23:54:04'),
('1', 'Test Test  Je dobio novac  Kolicina: 190', '2023-02-07 23:54:05'),
('1', 'Test Test  Je dobio novac  Kolicina: 463', '2023-02-07 23:54:06'),
('1', 'Test Test  Je dobio novac  Kolicina: 466', '2023-02-07 23:54:07'),
('1', 'Test Test  Je dobio novac  Kolicina: 449', '2023-02-07 23:54:08'),
('1', 'Test Test  Je dobio novac  Kolicina: 358', '2023-02-07 23:54:09'),
('1', 'Test Test  Je dobio novac  Kolicina: 299', '2023-02-07 23:54:10'),
('1', 'Test Test  Je dobio novac  Kolicina: 248', '2023-02-07 23:54:11'),
('1', 'Test Test  Je dobio novac  Kolicina: 142', '2023-02-07 23:54:12'),
('1', 'Test Test  Je dobio novac  Kolicina: 489', '2023-02-07 23:54:13'),
('1', 'Test Test  Je dobio novac  Kolicina: 258', '2023-02-07 23:54:14'),
('1', 'Test Test  Je dobio novac  Kolicina: 235', '2023-02-07 23:54:15'),
('1', 'Test Test  Je dobio novac  Kolicina: 211', '2023-02-07 23:54:16'),
('1', 'Test Test  Je dobio novac  Kolicina: 453', '2023-02-07 23:54:17'),
('1', 'Test Test  Je dobio novac  Kolicina: 263', '2023-02-07 23:54:18'),
('1', 'Test Test  Je dobio novac  Kolicina: 375', '2023-02-07 23:54:19'),
('1', 'Test Test  Je dobio novac  Kolicina: 192', '2023-02-07 23:54:20'),
('1', 'Test Test  Je dobio novac  Kolicina: 456', '2023-02-07 23:54:21'),
('1', 'Test Test  Je dobio novac  Kolicina: 440', '2023-02-07 23:54:22'),
('1', 'Test Test  Je dobio novac  Kolicina: 245', '2023-02-07 23:54:23'),
('1', 'Test Test  Je dobio novac  Kolicina: 196', '2023-02-07 23:54:24'),
('1', 'Test Test  Je dobio novac  Kolicina: 285', '2023-02-07 23:54:25'),
('1', 'Test Test  Je dobio novac  Kolicina: 173', '2023-02-07 23:54:26'),
('1', 'Test Test  Je dobio novac  Kolicina: 162', '2023-02-07 23:54:27'),
('1', 'Test Test  Je dobio novac  Kolicina: 245', '2023-02-07 23:54:28'),
('1', 'Test Test  Je dobio novac  Kolicina: 444', '2023-02-07 23:54:29'),
('1', 'Test Test  Je dobio novac  Kolicina: 221', '2023-02-07 23:54:30'),
('1', 'Test Test  Je dobio novac  Kolicina: 225', '2023-02-07 23:54:31'),
('1', 'Test Test  Je dobio novac  Kolicina: 275', '2023-02-07 23:54:32'),
('1', 'Test Test  Je dobio novac  Kolicina: 270', '2023-02-07 23:54:33'),
('1', 'Test Test  Je dobio novac  Kolicina: 234', '2023-02-07 23:54:34'),
('1', 'Test Test  Je dobio novac  Kolicina: 165', '2023-02-07 23:54:35'),
('1', 'Test Test  Je dobio novac  Kolicina: 351', '2023-02-07 23:54:36'),
('1', 'Test Test  Je dobio novac  Kolicina: 395', '2023-02-07 23:54:37'),
('1', 'Test Test  Je dobio novac  Kolicina: 292', '2023-02-07 23:54:38'),
('1', 'Test Test  Je dobio novac  Kolicina: 442', '2023-02-07 23:54:39'),
('1', 'Test Test  Je dobio novac  Kolicina: 203', '2023-02-07 23:54:40'),
('1', 'Test Test  Je dobio novac  Kolicina: 229', '2023-02-07 23:54:41'),
('1', 'Test Test  Je dobio novac  Kolicina: 413', '2023-02-07 23:54:42'),
('1', 'Test Test  Je dobio novac  Kolicina: 450', '2023-02-07 23:54:43'),
('1', 'Test Test  Je dobio novac  Kolicina: 112', '2023-02-07 23:54:44'),
('1', 'Test Test  Je dobio novac  Kolicina: 441', '2023-02-07 23:54:45'),
('1', 'Test Test  Je dobio novac  Kolicina: 374', '2023-02-07 23:54:46'),
('1', 'Test Test  Je dobio novac  Kolicina: 124', '2023-02-07 23:54:47'),
('1', 'Test Test  Je dobio novac  Kolicina: 343', '2023-02-07 23:54:48'),
('1', 'Test Test  Je dobio novac  Kolicina: 277', '2023-02-07 23:54:49'),
('1', 'Test Test  Je dobio novac  Kolicina: 139', '2023-02-07 23:54:50'),
('1', 'Test Test  Je dobio novac  Kolicina: 452', '2023-02-07 23:54:51'),
('1', 'Test Test  Je dobio novac  Kolicina: 165', '2023-02-07 23:54:52'),
('1', 'Test Test  Je dobio novac  Kolicina: 455', '2023-02-07 23:54:53'),
('1', 'Test Test  Je dobio novac  Kolicina: 413', '2023-02-07 23:54:54'),
('1', 'Test Test  Je dobio novac  Kolicina: 190', '2023-02-07 23:54:55'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-07 23:57:49'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-07 23:57:51'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-08 00:02:49'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-08 00:02:51'),
('3', 'Test Test  je /setleader igracu: Test Test organizacije: 1', '2023-02-08 00:05:22'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-09 18:39:00'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-09 18:39:02'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-09 18:46:28'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-09 18:46:29'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-09 18:47:55'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:5', '2023-02-09 18:47:59'),
('1', 'Hadehd  Je dobio novac  Kolicina: 434', '2023-02-09 18:49:53'),
('1', 'Hadehd  Je dobio novac  Kolicina: 685', '2023-02-09 18:49:54'),
('1', 'Hadehd  Je dobio novac  Kolicina: 851', '2023-02-09 18:49:55'),
('1', 'Hadehd  Je dobio novac  Kolicina: 688', '2023-02-09 18:49:56'),
('1', 'Hadehd  Je dobio novac  Kolicina: 532', '2023-02-09 18:49:57'),
('1', 'Hadehd  Je dobio novac  Kolicina: 571', '2023-02-09 18:49:58'),
('1', 'Hadehd  Je dobio novac  Kolicina: 813', '2023-02-09 18:49:59'),
('1', 'Hadehd  Je dobio novac  Kolicina: 527', '2023-02-09 18:50:00'),
('1', 'Hadehd  Je dobio novac  Kolicina: 630', '2023-02-09 18:50:01'),
('1', 'Hadehd  Je dobio novac  Kolicina: 502', '2023-02-09 18:50:02'),
('1', 'Hadehd  Je dobio novac  Kolicina: 620', '2023-02-09 18:50:03'),
('1', 'Hadehd  Je dobio novac  Kolicina: 418', '2023-02-09 18:50:04'),
('1', 'Hadehd  Je dobio novac  Kolicina: 820', '2023-02-09 18:50:05'),
('1', 'Hadehd  Je dobio novac  Kolicina: 663', '2023-02-09 18:50:06'),
('1', 'Hadehd  Je dobio novac  Kolicina: 549', '2023-02-09 18:50:07'),
('1', 'Hadehd  Je dobio novac  Kolicina: 638', '2023-02-09 18:50:08'),
('1', 'Hadehd  Je dobio novac  Kolicina: 489', '2023-02-09 18:50:09'),
('1', 'Hadehd  Je dobio novac  Kolicina: 670', '2023-02-09 18:50:10'),
('1', 'Hadehd  Je dobio novac  Kolicina: 838', '2023-02-09 18:50:11'),
('1', 'Hadehd  Je dobio novac  Kolicina: 720', '2023-02-09 18:50:12'),
('1', 'Hadehd  Je dobio novac  Kolicina: 629', '2023-02-09 18:50:13'),
('1', 'Hadehd  Je dobio novac  Kolicina: 765', '2023-02-09 18:50:14'),
('1', 'Hadehd  Je dobio novac  Kolicina: 534', '2023-02-09 18:50:15'),
('1', 'Hadehd  Je dobio novac  Kolicina: 468', '2023-02-09 18:50:16'),
('1', 'Hadehd  Je dobio novac  Kolicina: 653', '2023-02-09 18:50:17'),
('1', 'Hadehd  Je dobio novac  Kolicina: 480', '2023-02-09 18:50:18'),
('1', 'Hadehd  Je dobio novac  Kolicina: 690', '2023-02-09 18:50:19'),
('1', 'Hadehd  Je dobio novac  Kolicina: 884', '2023-02-09 18:50:20'),
('1', 'Hadehd  Je dobio novac  Kolicina: 618', '2023-02-09 18:50:21'),
('1', 'Hadehd  Je dobio novac  Kolicina: 835', '2023-02-09 18:50:22'),
('1', 'Hadehd  Je dobio novac  Kolicina: 763', '2023-02-09 18:50:23'),
('1', 'Hadehd  Je dobio novac  Kolicina: 670', '2023-02-09 18:50:24'),
('1', 'Hadehd  Je dobio novac  Kolicina: 415', '2023-02-09 18:50:25'),
('1', 'Hadehd  Je dobio novac  Kolicina: 729', '2023-02-09 18:50:26'),
('1', 'Hadehd  Je dobio novac  Kolicina: 724', '2023-02-09 18:50:27'),
('1', 'Hadehd  Je dobio novac  Kolicina: 430', '2023-02-09 18:50:28'),
('1', 'Hadehd  Je dobio novac  Kolicina: 408', '2023-02-09 18:50:29'),
('1', 'Hadehd  Je dobio novac  Kolicina: 598', '2023-02-09 18:50:30'),
('1', 'Hadehd  Je dobio novac  Kolicina: 664', '2023-02-09 18:50:31'),
('1', 'Hadehd  Je dobio novac  Kolicina: 678', '2023-02-09 18:50:32'),
('1', 'Hadehd  Je dobio novac  Kolicina: 697', '2023-02-09 18:50:33'),
('1', 'Hadehd  Je dobio novac  Kolicina: 771', '2023-02-09 18:50:34'),
('1', 'Hadehd  Je dobio novac  Kolicina: 502', '2023-02-09 18:50:35'),
('1', 'Hadehd  Je dobio novac  Kolicina: 756', '2023-02-09 18:50:36'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-09 19:06:07'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-09 19:06:11'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-09 19:40:56'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-09 19:59:10'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-09 19:59:15'),
('3', 'Hadehd  je /setleader igracu: Hadehd organizacije: 4', '2023-02-09 20:39:29'),
('1', 'Hadehd  Je dobio novac  Kolicina: -1000', '2023-02-09 22:59:34'),
('3', 'Hadehd  popravlja vozilo /fixcar: SA-ADMIN', '2023-02-09 23:09:09'),
('1', 'Hadehd  Je dobio novac  Kolicina: -650', '2023-02-10 12:49:34'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-10 12:50:23'),
('3', 'Hadehd je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-10 12:50:25'),
('3', 'Hadehd  je /setleader igracu: Hadehd organizacije: 8', '2023-02-10 12:50:35'),
('3', 'Hadehd  je /setskill igracu Hadehd vrednost: 150', '2023-02-10 13:09:42'),
('3', 'Hadehd  popravlja vozilo /fixcar: SA-ADMIN', '2023-02-10 13:14:52'),
('3', 'Hadehd  popravlja vozilo /fixcar: SA-ADMIN', '2023-02-10 16:48:27'),
('3', 'Hadehd  je /setvip igracu Hadehd dana: 10', '2023-02-10 17:00:28'),
('3', 'Hadehd  popravlja vozilo /fixcar: SA-ADMIN', '2023-02-10 17:31:38'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: 0', '2023-02-10 17:33:37'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: 0', '2023-02-10 17:33:37'),
('3', 'Hadehd  je koristio /revive na: Hadehd', '2023-02-10 18:15:02'),
('3', 'Hadehd  popravlja vozilo /fixcar: SA-ADMIN', '2023-02-10 18:40:22'),
('3', 'Hadehd  je koristio /revive na: Hadehd', '2023-02-11 12:27:03'),
('3', 'Hadehd  je /setbusiness igracu Hadehd biznis: 0', '2023-02-11 20:11:06'),
('3', 'Hadehd  je /setbusiness igracu Hadehd biznis: 0', '2023-02-11 20:14:33'),
('3', 'Hadehd  je /setbizmoney na 0 biz ID: 0', '2023-02-11 20:15:20'),
('3', 'Hadehd  je /setbusiness igracu Hadehd biznis: 0', '2023-02-11 20:27:50'),
('1', 'Hadehd  Je dobio novac  Kolicina: 500', '2023-02-11 20:30:50'),
('1', 'Hadehd  Je dobio novac  Kolicina: 500', '2023-02-11 20:30:51'),
('1', 'Hadehd  Je dobio novac  Kolicina: 500', '2023-02-11 20:30:52');
INSERT INTO `server_log` (`log_type`, `log_message`, `log_time`) VALUES
('1', 'Hadehd  Je dobio novac  Kolicina: 500', '2023-02-11 20:32:49'),
('1', 'Hadehd  Je dobio novac  Kolicina: 0', '2023-02-11 20:32:51'),
('1', 'Hadehd  Je dobio novac  Kolicina: 0', '2023-02-11 20:32:52'),
('1', 'Hadehd  Je dobio novac  Kolicina: 0', '2023-02-11 20:32:54'),
('1', 'Hadehd  Je dobio novac  Kolicina: 0', '2023-02-11 20:32:55'),
('1', 'Hadehd  Je dobio novac  Kolicina: 0', '2023-02-11 20:32:59'),
('1', 'Hadehd  Je dobio novac  Kolicina: -2', '2023-02-11 20:40:58'),
('1', 'Hadehd  Je dobio novac  Kolicina: 50', '2023-02-11 20:40:58'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: -50', '2023-02-11 20:40:58'),
('1', 'Hadehd  Je dobio novac  Kolicina: 0', '2023-02-11 21:01:55'),
('1', 'Hadehd  Je dobio novac  Kolicina: 10', '2023-02-11 21:01:55'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: -10', '2023-02-11 21:01:55'),
('1', 'Hadehd  Je dobio novac  Kolicina: 0', '2023-02-11 21:02:09'),
('1', 'Hadehd  Je dobio novac  Kolicina: 10', '2023-02-11 21:02:09'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: -10', '2023-02-11 21:02:09'),
('1', 'Hadehd  Je dobio novac  Kolicina: 5000', '2023-02-11 21:05:41'),
('1', 'Hadehd  Je dobio novac  Kolicina: 5000', '2023-02-11 21:05:49'),
('1', 'Hadehd  Je dobio novac  Kolicina: 5000', '2023-02-11 21:05:51'),
('1', 'Hadehd  Je dobio novac  Kolicina: 5000', '2023-02-11 21:05:59'),
('1', 'Hadehd  Je dobio novac  Kolicina: 5000', '2023-02-11 21:06:00'),
('1', 'Hadehd  Je dobio novac  Kolicina: 5000', '2023-02-11 21:06:00'),
('1', 'Hadehd  Je dobio novac  Kolicina: 5000', '2023-02-11 21:06:01'),
('1', 'Hadehd  Je dobio novac  Kolicina: 200', '2023-02-11 21:11:27'),
('1', 'Hadehd  Je dobio novac  Kolicina: 10', '2023-02-11 21:15:18'),
('1', 'Hadehd  Je dobio novac  Kolicina: 400', '2023-02-11 21:15:28'),
('1', 'Hadehd  Je dobio novac  Kolicina: 100', '2023-02-11 21:15:33'),
('1', 'Hadehd  Je dobio novac  Kolicina: 100', '2023-02-11 21:18:15'),
('1', 'Hadehd  Je dobio novac  Kolicina: 440', '2023-02-11 21:18:25'),
('1', 'Hadehd  Je dobio novac  Kolicina: 10', '2023-02-11 22:52:41'),
('1', 'Hadehd  Je dobio novac  Kolicina: 40', '2023-02-11 22:52:51'),
('1', 'Hadehd  Je dobio novac  Kolicina: 10', '2023-02-12 00:15:00'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: 10000', '2023-02-12 00:30:35'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: -2000', '2023-02-12 00:30:35'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: 8000', '2023-02-12 00:34:16'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: 8000', '2023-02-12 00:34:20'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: 8000', '2023-02-12 00:34:33'),
('1', 'Hadehd  Je dobio novac  Kolicina: 475', '2023-02-12 00:36:31'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: -500', '2023-02-12 00:36:31'),
('1', 'Hadehd  Je dobio novac  Kolicina: 475', '2023-02-12 00:36:35'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: -500', '2023-02-12 00:36:35'),
('1', 'Hadehd  Je dobio novac  Kolicina: 475', '2023-02-12 00:36:37'),
('1', 'Hadehd  Je primio novac Banka:  Kolicina: -500', '2023-02-12 00:36:37'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 16:54:38'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 16:55:42'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 16:59:08'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 17:01:28'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 17:02:11'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 17:03:26'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 17:04:44'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 17:05:28'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 17:12:33'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 17:13:12'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 17:14:16'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 17:15:30'),
('1', 'Hadehd  Je primio platu:  Kolicina: 110', '2023-02-12 17:16:04'),
('3', 'Hadehd  je /setleader igracu: Hadehd organizacije: 3', '2023-02-12 17:29:51'),
('1', 'Hadehd  Je dobio novac  Kolicina: -50', '2023-02-12 23:01:25'),
('1', 'Hadehd  Je dobio novac  Kolicina: -50', '2023-02-12 23:08:04'),
('1', 'Hadehd  Je dobio novac  Kolicina: -50', '2023-02-12 23:29:54'),
('3', 'Hadehd  je postavio dimenziju igracu: Hadehd', '2023-02-12 23:35:13'),
('1', 'Hadehd  Je dobio novac  Kolicina: -50', '2023-02-12 23:35:21'),
('1', 'Hadehd  Je dobio novac  Kolicina: -50', '2023-02-12 23:46:25'),
('1', 'Hadehd  Je dobio novac  Kolicina: -50', '2023-02-13 00:34:24'),
('3', 'Hadehd  popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-13 00:56:54'),
('1', 'Hadehd  Je dobio novac  Kolicina: -100', '2023-02-13 01:07:01'),
('3', 'Hadehd  popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-13 01:08:18'),
('3', 'Hadehd  popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-13 01:08:59'),
('3', 'Hadehd  popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-13 01:16:44'),
('3', 'Hadehd  popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-13 01:17:00'),
('3', 'Hadehd  popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-13 01:25:56'),
('3', 'Hadehd  popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-13 01:26:50'),
('3', 'Hadehd  popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-13 02:04:57'),
('3', 'Hadehd  popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-13 02:06:40'),
('3', 'Hadehd  je postavio vrednost healtha /sethp: Hadehd na: 100', '2023-02-13 19:09:27'),
('3', 'Hadehd  je koristio /revive na: Hadehd', '2023-02-13 19:11:59'),
('3', 'Hadehd  je postavio vrednost healtha /sethp: Hadehd na: 100', '2023-02-13 19:12:26'),
('1', 'Hadehd  Je dobio novac  Kolicina: -30', '2023-02-13 19:13:28'),
('1', 'Hadehd  Je dobio novac  Kolicina: -30', '2023-02-13 19:13:29'),
('1', 'Hadehd  Je dobio novac  Kolicina: -1000', '2023-02-13 19:13:30'),
('1', 'Hadehd  Je dobio novac  Kolicina: -30', '2023-02-13 19:13:31'),
('1', 'Hadehd  Je dobio novac  Kolicina: -25', '2023-02-13 19:13:31'),
('1', 'Hadehd  Je dobio novac  Kolicina: -25', '2023-02-13 19:13:32'),
('1', 'Hadehd  Je dobio novac  Kolicina: -25', '2023-02-13 19:13:32'),
('3', 'Hadehd  je koristio /freeze !: True', '2023-02-13 19:54:12'),
('3', 'Hadehd  je koristio /freeze !: False', '2023-02-13 19:54:16'),
('1', 'Test Tester  Set Novac na:  Kolicina: 2000', '2023-02-13 19:56:43'),
('1', 'Test Tester  Set Novac Na (Banka):  Kolciina: 5000', '2023-02-13 19:56:43'),
('3', 'Test Tester  je /setvip igracu Test Tester dana: 1', '2023-02-14 03:18:00'),
('3', 'Test Tester  je /setvip igracu Test Tester dana: 1', '2023-02-14 03:18:10'),
('3', 'Test Tester  je /setvip igracu Test Tester dana: 10', '2023-02-14 03:18:19'),
('1', 'Test Tester  Je dobio novac  Kolicina: -30', '2023-02-14 03:57:44'),
('1', 'Test Tester  Je dobio novac  Kolicina: -30', '2023-02-14 03:58:44'),
('1', 'Test Tester  Je dobio novac  Kolicina: -30', '2023-02-14 03:59:44'),
('1', 'Test Tester  Je dobio novac  Kolicina: -30', '2023-02-14 04:00:45'),
('3', 'Test Tester  popravlja vozilo /fixcar: rtTest Tester', '2023-02-14 04:01:06'),
('1', 'Test Tester  Je dobio novac  Kolicina: -30', '2023-02-14 04:01:45'),
('1', 'Test Tester  Je dobio novac  Kolicina: -30', '2023-02-14 04:02:45'),
('1', 'Test Tester  Je dobio novac  Kolicina: -30', '2023-02-14 04:03:45'),
('3', 'Test Tester  je /setleader igracu: Test Tester organizacije: 1', '2023-02-14 04:25:13'),
('3', 'Test Tester  je /givemoney igracu: Test Tester vrednost: 99999', '2023-02-14 04:26:01'),
('1', 'Test Tester  Je dobio novac  Kolicina: 99999', '2023-02-14 04:26:01'),
('1', 'Test Tester  Je dobio novac  Kolicina: -20000', '2023-02-14 04:26:02'),
('3', 'Test Tester  je /givemoney igracu: Test Tester vrednost: 99999', '2023-02-14 04:26:16'),
('1', 'Test Tester  Je dobio novac  Kolicina: 99999', '2023-02-14 04:26:16'),
('1', 'Test Tester  Je primio platu:  Kolicina: 110', '2023-02-15 17:36:41'),
('1', 'Test Tester  Je primio platu:  Kolicina: 110', '2023-02-15 17:45:57'),
('1', 'Test Tester  Je primio platu:  Kolicina: 110', '2023-02-15 17:47:59'),
('1', 'Test Tester  Je primio platu:  Kolicina: 110', '2023-02-15 17:51:30'),
('1', 'Test Tester  Je primio platu:  Kolicina: 110', '2023-02-15 18:41:17'),
('3', 'Test Tester  je postavio dimenziju igracu: Test Tester', '2023-02-15 19:52:04'),
('3', 'Test Tester  je postavio dimenziju igracu: Test Tester', '2023-02-15 20:04:35'),
('3', 'Test Tester  popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-15 21:46:55'),
('1', 'Test Tester  Je dobio novac  Kolicina: -1000', '2023-02-15 23:52:34'),
('1', 'Test Tester  Je dobio novac  Kolicina: -1000', '2023-02-15 23:54:06'),
('3', 'Test Tester  je /setleader igracu: Test Tester organizacije: 1', '2023-02-17 00:01:03'),
('3', 'Test Tester  je /givemoney igracu: Test Tester vrednost: 99999999', '2023-02-17 00:18:32'),
('1', 'Test Tester  Je dobio novac  Kolicina: 99999999', '2023-02-17 00:18:32'),
('1', 'Test Tester  Je dobio novac  Kolicina: -999999', '2023-02-17 00:19:17'),
('1', 'Test Tester  Je primio novac Banka:  Kolicina: 999999', '2023-02-17 00:19:17'),
('1', 'Test Tester  Je dobio novac  Kolicina: -999999', '2023-02-17 00:19:18'),
('1', 'Test Tester  Je primio novac Banka:  Kolicina: 999999', '2023-02-17 00:19:18'),
('1', 'Test Tester  Je dobio novac  Kolicina: -999999', '2023-02-17 00:19:19'),
('1', 'Test Tester  Je primio novac Banka:  Kolicina: 999999', '2023-02-17 00:19:19'),
('1', 'Test Tester  Je dobio novac  Kolicina: -999999', '2023-02-17 00:19:19'),
('1', 'Test Tester  Je primio novac Banka:  Kolicina: 999999', '2023-02-17 00:19:19'),
('1', 'Test Tester  Je dobio novac  Kolicina: -999999', '2023-02-17 00:19:20'),
('1', 'Test Tester  Je primio novac Banka:  Kolicina: 999999', '2023-02-17 00:19:20'),
('1', 'Test Tester  Je dobio novac  Kolicina: -999999', '2023-02-17 00:19:20'),
('1', 'Test Tester  Je primio novac Banka:  Kolicina: 999999', '2023-02-17 00:19:20'),
('1', 'Test Tester  Je dobio novac  Kolicina: -999999', '2023-02-17 00:19:20'),
('1', 'Test Tester  Je primio novac Banka:  Kolicina: 999999', '2023-02-17 00:19:20'),
('1', 'Test Tester  Je primio novac Banka:  Kolicina: -640000', '2023-02-17 00:19:41'),
('1', 'Test Tester  Je dobio novac  Kolicina: -4000', '2023-02-17 00:38:52'),
('1', 'Test Tester  Je dobio novac  Kolicina: -5000', '2023-02-17 01:44:03'),
('3', 'Test Tester  popravlja vozilo /fixcar: P753XK', '2023-02-17 12:45:14'),
('3', 'Test Tester je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-02-17 12:58:58'),
('3', 'Test Tester je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-02-17 12:59:01'),
('3', 'Test Tester  je /setleader igracu: Test Tester organizacije: 8', '2023-02-17 12:59:07'),
('3', 'Test Tester  je /setskill igracu Test Tester vrednost: 150', '2023-02-17 13:03:08'),
('1', 'Test Tester  Je dobio novac  Kolicina: 85000', '2023-02-17 13:03:49'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:15:39'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:15:42'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:15:47'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:15:52'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:15:57'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:15:59'),
('3', 'Test Tester  je postavio dimenziju igracu: Test Tester', '2023-02-17 13:17:55'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:18:57'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:18:59'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:19:01'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:19:03'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:19:05'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:19:06'),
('3', 'Test Tester  je postavio dimenziju igracu: Test Tester', '2023-02-17 13:19:22'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:20:19'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:20:22'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:20:23'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:20:25'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:20:26'),
('1', 'Test Tester  Je dobio novac  Kolicina: -500', '2023-02-17 13:20:28'),
('3', 'Test Tester  je /setbusiness igracu Test Tester biznis: 1', '2023-02-17 13:23:33'),
('1', 'Test Tester  Je dobio novac  Kolicina: -50', '2023-02-17 13:24:32'),
('1', 'Test Tester  Je primio platu:  Kolicina: 30', '2023-02-17 13:27:45'),
('1', 'Test Tester  Je primio platu:  Kolicina: 110', '2023-02-17 13:27:45'),
('1', 'Test Tester  Je primio platu:  Kolicina: 30', '2023-02-17 13:28:37'),
('1', 'Test Tester  Je primio platu:  Kolicina: 110', '2023-02-17 13:28:37'),
('1', 'Test Tester  Je primio platu:  Kolicina: 30', '2023-02-17 13:29:51'),
('1', 'Test Tester  Je primio platu:  Kolicina: 110', '2023-02-17 13:29:51'),
('1', 'Test Tester  Je primio platu:  Kolicina: 30', '2023-02-17 13:32:10'),
('1', 'Test Tester  Je primio platu:  Kolicina: 110', '2023-02-17 13:32:10'),
('1', 'Test Tester  Je primio platu:  Kolicina: 30', '2023-02-17 13:33:06'),
('1', 'Test Tester  Je primio platu:  Kolicina: 110', '2023-02-17 13:33:06'),
('3', 'Test Tester  je /setbusiness igracu Test Tester biznis: 1', '2023-02-17 13:33:45'),
('1', 'Test Tester  Je primio novac Banka:  Kolicina: 400', '2023-02-17 13:34:57'),
('1', 'Test Tester  Je primio novac Banka:  Kolicina: 0', '2023-02-17 14:18:17'),
('1', 'Test Tester  Je primio novac Banka:  Kolicina: 0', '2023-02-17 14:18:17'),
('1', 'Test Tester  Je dobio novac  Kolicina: -5000', '2023-02-17 15:22:02'),
('1', 'Test Tester  Je dobio novac  Kolicina: -5000', '2023-02-17 15:23:52'),
('1', 'Test Tester  Je dobio novac  Kolicina: -5000', '2023-02-17 15:28:32'),
('1', 'Test Tester  Je dobio novac  Kolicina: -100', '2023-02-17 15:34:57'),
('1', 'Test Tester  Je dobio novac  Kolicina: -324', '2023-02-17 15:36:07'),
('3', 'Test Tester  popravlja vozilo /fixcar: P753XK', '2023-02-17 15:39:09'),
('3', 'Test Tester  popravlja vozilo /fixcar: P753XK', '2023-02-17 15:40:18'),
('3', 'Test Tester  popravlja vozilo /fixcar: P753XK', '2023-02-17 15:41:02'),
('3', 'Test Tester  popravlja vozilo /fixcar: P753XK', '2023-02-17 15:41:29'),
('3', 'Test Tester  popravlja vozilo /fixcar: P753XK', '2023-02-17 15:41:49'),
('3', 'Test Tester  popravlja vozilo /fixcar: P753XK', '2023-02-17 15:42:05'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:16:33'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:16:35'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:16:38'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:16:42'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:16:44'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:16:46'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:55:15'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:55:18'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:55:19'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:55:20'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:55:21'),
('1', 'Test Tester  Je dobio novac  Kolicina: -2000', '2023-02-17 16:55:23'),
('1', 'Test Tester  Je dobio novac  Kolicina: -3000', '2023-02-17 17:04:27'),
('1', 'Test Tester  Je dobio novac  Kolicina: -3000', '2023-02-17 17:04:28'),
('1', 'Test Tester  Je dobio novac  Kolicina: -3000', '2023-02-17 17:04:29'),
('1', 'Test Tester  Je dobio novac  Kolicina: -3000', '2023-02-17 17:04:30'),
('1', 'Test Tester  Je dobio novac  Kolicina: -3000', '2023-02-17 17:04:31'),
('1', 'Test Tester  Je dobio novac  Kolicina: -3000', '2023-02-17 17:04:33'),
('1', 'Test Tester  Je dobio novac  Kolicina: -3000', '2023-02-17 17:04:33'),
('1', 'Hadehd  Je dobio novac  Kolicina: -3000', '2023-02-17 17:08:18'),
('1', 'Hadehd  Je dobio novac  Kolicina: -3000', '2023-02-17 17:08:21'),
('1', 'Hadehd  Je dobio novac  Kolicina: -3000', '2023-02-17 17:08:30'),
('1', 'Hadehd  Je dobio novac  Kolicina: -3000', '2023-02-17 17:10:35'),
('1', 'Hadehd  Je dobio novac  Kolicina: -3000', '2023-02-17 17:10:36'),
('1', 'Hadehd  Je dobio novac  Kolicina: -3000', '2023-02-17 17:10:38'),
('1', 'Hadehd  Je dobio novac  Kolicina: -3000', '2023-02-17 17:10:40'),
('1', 'Hadehd  Je dobio novac  Kolicina: -3000', '2023-02-17 17:10:42'),
('1', 'Hadehd  Je dobio novac  Kolicina: -3000', '2023-02-17 17:10:43'),
('1', 'Test Tester  Set Novac na:  Kolicina: 2000', '2023-02-17 18:05:17'),
('1', 'Test Tester  Set Novac Na (Banka):  Kolciina: 5000', '2023-02-17 18:05:17'),
('1', 'Hadehd  Je dobio novac  Kolicina: -3000', '2023-02-17 18:14:46'),
('3', 'Hadehd  je /givemoney igracu: Hadehd vrednost: 99999', '2023-02-17 18:30:52'),
('1', 'Hadehd  Je dobio novac  Kolicina: 99999', '2023-02-17 18:30:52'),
('1', 'Hadehd  Je dobio novac  Kolicina: -5000', '2023-02-17 18:31:00'),
('1', 'Hadehd  Je dobio novac  Kolicina: -20000', '2023-02-17 18:48:24'),
('3', 'Hadehd   je /setleader igracu: Hadehd  organizacije: 1', '2023-02-18 14:40:36'),
('1', 'Test Tester  Set Novac na:  Kolicina: 10000', '2023-02-18 14:54:00'),
('1', 'Test Tester  Set Novac Na (Banka):  Kolciina: 20000', '2023-02-18 14:54:00'),
('1', 'Test Test  Set Novac na:  Kolicina: 10000', '2023-02-18 14:59:12'),
('1', 'Test Test  Set Novac Na (Banka):  Kolciina: 20000', '2023-02-18 14:59:12'),
('3', 'Test Test  je /setleader igracu: Test Test organizacije: 1', '2023-02-18 16:33:07'),
('1', 'Test Test  Je dobio novac  Kolicina: -100', '2023-02-18 16:53:54'),
('1', 'Test Test  Je dobio novac  Kolicina: 20', '2023-02-18 16:54:02'),
('1', 'Test Test  Je dobio novac  Kolicina: -100', '2023-02-18 16:54:04'),
('1', 'Test Test  Je dobio novac  Kolicina: 1', '2023-02-18 16:54:12'),
('1', 'Test Test  Je primio platu:  Kolicina: 9500', '2023-02-18 23:40:18'),
('3', 'Test Test  je /givemoney igracu: Test Test vrednost: 99999999', '2023-02-18 23:41:20'),
('1', 'Test Test  Je dobio novac  Kolicina: 99999999', '2023-02-18 23:41:20'),
('1', 'Test Test  Je dobio novac  Kolicina: -999999', '2023-02-18 23:41:29'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: 999999', '2023-02-18 23:41:29'),
('1', 'Test Test  Je dobio novac  Kolicina: -999999', '2023-02-18 23:41:30'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: 999999', '2023-02-18 23:41:30'),
('1', 'Test Test  Je dobio novac  Kolicina: -999999', '2023-02-18 23:41:30'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: 999999', '2023-02-18 23:41:30'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -640000', '2023-02-18 23:41:35'),
('1', 'Test Test  Je primio platu:  Kolicina: 9500', '2023-02-18 23:44:10'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 64 | kolicina:1', '2023-02-18 23:50:25'),
('1', 'Test Test  Je dobio novac  Kolicina: 1500', '2023-02-18 23:52:40'),
('3', 'Test Test  je /givemoney igracu: Test Test vrednost: -97011323', '2023-02-18 23:52:55'),
('1', 'Test Test  Je dobio novac  Kolicina: -97011323', '2023-02-18 23:52:55'),
('3', 'Test Test je dao item igracu GTANetworkAPI.Player | ime itema: 64 | kolicina:5', '2023-02-18 23:53:10'),
('1', 'Test Test  Je dobio novac  Kolicina: 1500', '2023-02-18 23:53:12'),
('1', 'Test Test  Je dobio novac  Kolicina: 6000', '2023-02-18 23:53:44'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2278', '2023-02-19 13:26:11'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -1625', '2023-02-19 13:28:12'),
('1', 'Test Test  Je dobio novac  Kolicina: -1000', '2023-02-19 14:11:56'),
('3', 'Test Test  je /givemoney igracu: Test Test vrednost: 20000', '2023-02-19 15:33:23'),
('1', 'Test Test  Je dobio novac  Kolicina: 20000', '2023-02-19 15:33:23'),
('1', 'Test Test  Je dobio novac  Kolicina: -20000', '2023-02-19 15:33:25'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -500', '2023-02-19 16:38:17'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:19'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:20'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:20'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:21'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:21'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:21'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:23'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:23'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:24'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:24'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:26'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:26'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -2', '2023-02-19 16:40:30'),
('1', 'Test Test  Je primio novac Banka:  Kolicina: -5', '2023-02-19 17:11:58'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -100', '2023-02-19 17:21:51'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-02-19 19:56:46'),
('3', 'Hadehd   popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-20 14:11:46'),
('3', 'Hadehd   popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-20 14:12:24'),
('3', 'Hadehd   popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-20 14:17:09'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -357', '2023-02-20 15:46:29'),
('3', 'Hadehd   je /setleader igracu: Hadehd  organizacije: 8', '2023-02-21 21:04:21'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 0', '2023-02-21 22:09:07'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 0', '2023-02-21 22:09:08'),
('1', 'Hadehd   Je dobio novac  Kolicina: 949999', '2023-02-24 14:22:12'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -999999', '2023-02-24 14:22:12'),
('1', 'Hadehd   Je dobio novac  Kolicina: 949999', '2023-02-24 14:22:12'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -999999', '2023-02-24 14:22:12'),
('3', 'Hadehd   je /setleader igracu: Hadehd  organizacije: 1', '2023-02-24 19:01:46'),
('1', 'Hadehd   Je dobio novac  Kolicina: -27000', '2023-02-24 22:20:57'),
('1', 'Hadehd   Je dobio novac  Kolicina: -18000', '2023-02-24 22:21:07'),
('1', 'Hadehd   Je dobio novac  Kolicina: -6000', '2023-02-24 22:22:38'),
('1', 'Hadehd   Je dobio novac  Kolicina: -3000', '2023-02-24 22:23:42'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-02-25 11:49:33'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:36:23'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:36:23'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:36:23'),
('3', 'Hadehd   popravlja vozilo /fixcar: M574BK24', '2023-02-25 12:43:37'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:43:56'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:43:56'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:43:56'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -10500', '2023-02-25 12:44:13'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -4500', '2023-02-25 12:45:51'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:50:47'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:50:47'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:50:47'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:56:34'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:56:34'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 12:56:34'),
('3', 'Hadehd   popravlja vozilo /fixcar: M574BK24', '2023-02-25 12:56:43'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:00:32'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:00:32'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:00:32'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:16:51'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:16:51'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:16:51'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:16:59'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:16:59'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:16:59'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:49:37'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:49:37'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:49:37'),
('3', 'Hadehd   popravlja vozilo /fixcar: M574BK24', '2023-02-25 13:52:15'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:52:29'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:52:29'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:52:30'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:58:39'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:58:39'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 13:58:39'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:10:01'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:10:01'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:10:01'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:15:38'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:15:38'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:15:38'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:47:12'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:47:12'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:47:12'),
('3', 'Hadehd   je /setleader igracu: Hadehd  organizacije: 1', '2023-02-25 14:47:46'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-02-25 14:47:55'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:58:38'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:58:38'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 14:58:38'),
('3', 'Hadehd   popravlja vozilo /fixcar: M574BK24', '2023-02-25 14:58:49'),
('3', 'Hadehd   popravlja vozilo /fixcar: M574BK24', '2023-02-25 14:59:49'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -40000', '2023-02-25 15:01:10'),
('3', 'Hadehd   popravlja vozilo /fixcar: M574BK24', '2023-02-25 15:01:55'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:08:27'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:08:27'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:08:27'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:18:59'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:18:59'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:18:59'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:21:54'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:21:54'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:21:55'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:27:27'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:27:28'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:27:28'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:32:29'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:32:29'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-25 15:32:29'),
('1', 'Hadehd   Je dobio novac  Kolicina: -5000', '2023-02-25 16:25:48'),
('3', 'Hadehd   popravlja vozilo /fixcar: HADEHD', '2023-02-25 16:51:56'),
('3', 'Hadehd   popravlja vozilo /fixcar: HADEHD', '2023-02-25 16:52:23'),
('3', 'Hadehd   je /setvip igracu Hadehd  dana: 10', '2023-02-25 17:44:45'),
('3', 'Hadehd   je /setxp igracu: Hadehd  na: 50', '2023-02-25 19:29:38'),
('3', 'Hadehd   je /setxp igracu: Hadehd  na: 50', '2023-02-25 19:29:40'),
('3', 'Hadehd   je /setxp igracu: Hadehd  na: 6000', '2023-02-25 19:29:48'),
('3', 'Hadehd   je /setxp igracu: Hadehd  na: 300', '2023-02-25 19:30:03'),
('3', 'Hadehd   je /setxp igracu: Hadehd  na: 300', '2023-02-25 19:30:07'),
('3', 'Hadehd   je /setxp igracu: Hadehd  na: 300', '2023-02-25 19:30:09'),
('1', 'Hadehd   Je dobio novac  Kolicina: -100', '2023-02-25 19:34:40'),
('1', 'Hadehd   Je dobio novac  Kolicina: 150', '2023-02-25 19:42:59'),
('3', 'Hadehd   je /givemoney igracu: Hadehd  vrednost: -1835548', '2023-02-25 20:16:42'),
('1', 'Hadehd   Je dobio novac  Kolicina: -1835548', '2023-02-25 20:16:42'),
('3', 'Hadehd   je /givemoney igracu: Hadehd  vrednost: 100', '2023-02-25 20:16:53'),
('1', 'Hadehd   Je dobio novac  Kolicina: 100', '2023-02-25 20:16:53'),
('1', 'Hadehd   Je dobio novac  Kolicina: -100', '2023-02-25 20:17:00'),
('1', 'Hadehd   Je dobio novac  Kolicina: 3000', '2023-02-25 20:17:00'),
('1', 'Hadehd   Je dobio novac  Kolicina: 3000', '2023-02-25 20:19:35'),
('1', 'Hadehd   Je dobio novac  Kolicina: 3000', '2023-02-25 20:22:50'),
('1', 'Hadehd   Je dobio novac  Kolicina: 3000', '2023-02-25 20:24:36'),
('1', 'Hadehd   Je dobio novac  Kolicina: -100', '2023-02-25 20:25:22'),
('1', 'Hadehd   Je dobio novac  Kolicina: 3000', '2023-02-25 20:25:22'),
('1', 'Hadehd   Je dobio novac  Kolicina: -80', '2023-02-25 20:25:43'),
('1', 'Hadehd   Je dobio novac  Kolicina: 3000', '2023-02-25 20:25:43'),
('1', 'Hadehd   Je dobio novac  Kolicina: 150', '2023-02-25 20:26:41'),
('1', 'Hadehd   Je dobio novac  Kolicina: 3000', '2023-02-25 20:26:41'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-02-27 15:00:43'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-02-27 16:00:43'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-02-27 17:00:43'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-02-27 18:00:43'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-02-27 19:00:43'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-02-27 20:00:43'),
('3', 'Hadehd   popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-27 20:19:10'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-02-27 21:00:43'),
('3', 'Hadehd   je koristio /getcar : Y733MK88', '2023-02-28 14:18:18'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-28 14:25:03'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-28 14:25:03'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-28 14:25:03'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-28 14:38:18'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-28 14:38:18'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-28 14:38:18'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-28 14:42:07'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-28 14:42:07'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-02-28 14:42:07'),
('1', 'Hadehd   Je dobio novac  Kolicina: 272650', '2023-02-28 14:59:28'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -287000', '2023-02-28 14:59:28'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 15:38:26'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 15:50:56'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 15:59:17'),
('3', 'Hadehd   je koristio /freeze !: False', '2023-02-28 15:59:23'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-02-28 16:00:36'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 16:16:12'),
('3', 'Hadehd   je koristio /freeze !: False', '2023-02-28 16:16:35'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 16:16:38'),
('3', 'Hadehd   je koristio /freeze !: False', '2023-02-28 16:37:05'),
('3', 'Hadehd   je koristio /freeze !: False', '2023-02-28 16:40:31'),
('3', 'Hadehd   popravlja vozilo /fixcar: RPV-ADMIN', '2023-02-28 16:49:51'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-02-28 17:00:23'),
('3', 'Hadehd   je /setbusiness igracu Hadehd  biznis: 3', '2023-02-28 17:26:12'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 18300', '2023-02-28 17:26:21'),
('1', 'Hadehd   Je dobio novac  Kolicina: 4750', '2023-02-28 17:26:46'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -5000', '2023-02-28 17:26:46'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 18:01:57'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 18:03:39'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 18:06:22'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 18:10:05'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 18:12:39'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 18:15:15'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 18:18:30'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 18:23:50'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 18:35:36'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 18:46:11'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-02-28 19:00:30'),
('1', 'Hadehd   Je dobio novac  Kolicina: -277777', '2023-02-28 20:16:36'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 277777', '2023-02-28 20:16:36'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-02-28 20:21:40'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-01 18:00:02'),
('3', 'Hadehd   je koristio /revive na: Hadehd ', '2023-03-02 12:05:12'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-02 13:00:20'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-03-02 16:20:04'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-03-02 16:20:06'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-03-02 16:20:12'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-03-02 16:20:13'),
('3', 'Hadehd   je /setskill igracu Hadehd  vrednost: 150', '2023-03-02 16:25:15'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-03-02 16:52:24'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-03-02 16:52:30'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-03-02 16:57:00'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-02 17:00:37'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-03-02 17:07:44'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-03-02 17:07:46'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-03-02 17:12:01'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-03-02 17:12:03'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-02 19:00:56'),
('3', 'Hadehd   je /setleader igracu: Hadehd  organizacije: 4', '2023-03-02 19:05:57'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 28 | kolicina:1', '2023-03-02 19:52:59'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-03-02 19:53:28'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-02 20:10:54'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-04 18:02:12'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-04 18:02:53'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-04 18:03:41'),
('3', 'Hadehd   je /setleader igracu: Hadehd  organizacije: 1', '2023-03-04 18:10:10'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-04 18:10:43'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-04 18:10:47'),
('3', 'Hadehd   je /givemoney igracu: Hadehd  vrednost: 99999', '2023-03-04 18:12:15'),
('1', 'Hadehd   Je dobio novac  Kolicina: 99999', '2023-03-04 18:12:15'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-04 18:12:17'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-04 18:15:42'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-04 18:16:55'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-04 18:18:18'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-04 18:22:06'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-04 18:29:42'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-04 18:29:42'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-04 18:29:42'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-04 18:37:27'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-04 18:37:27'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-04 18:37:27'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-04 18:39:28'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -10500', '2023-03-04 18:40:39'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 150', '2023-03-04 18:40:58'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -40000', '2023-03-04 18:41:22'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-04 19:00:45'),
('1', 'Hadehd   Je dobio novac  Kolicina: 400', '2023-03-04 19:33:59'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 1 | kolicina:1', '2023-03-04 19:35:08'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 2 | kolicina:1', '2023-03-04 19:35:11'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 3 | kolicina:1', '2023-03-04 19:35:15'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 4 | kolicina:1', '2023-03-04 19:35:18'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 5 | kolicina:1', '2023-03-04 19:35:20'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 6 | kolicina:1', '2023-03-04 19:35:45'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 7 | kolicina:1', '2023-03-04 19:35:47'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 8 | kolicina:1', '2023-03-04 19:35:49'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 9 | kolicina:1', '2023-03-04 19:35:51'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 10 | kolicina:1', '2023-03-04 19:35:54'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 11 | kolicina:1', '2023-03-04 19:37:03'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 12 | kolicina:1', '2023-03-04 19:37:04'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 13 | kolicina:1', '2023-03-04 19:37:06'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 14 | kolicina:1', '2023-03-04 19:37:08'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 15 | kolicina:1', '2023-03-04 19:37:10'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 16 | kolicina:1', '2023-03-04 19:40:28'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 17 | kolicina:1', '2023-03-04 19:40:30'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 18 | kolicina:1', '2023-03-04 19:40:31'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 19 | kolicina:1', '2023-03-04 19:40:33'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 20 | kolicina:1', '2023-03-04 19:40:38'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 15 | kolicina:1', '2023-03-04 19:40:44'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 16 | kolicina:1', '2023-03-04 19:40:49'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 21 | kolicina:1', '2023-03-04 19:41:42'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 22 | kolicina:1', '2023-03-04 19:41:44'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 23 | kolicina:1', '2023-03-04 19:41:45'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 24 | kolicina:1', '2023-03-04 19:41:48'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 25 | kolicina:1', '2023-03-04 19:41:51'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 26 | kolicina:1', '2023-03-04 19:41:53'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 27 | kolicina:1', '2023-03-04 19:41:54'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 28 | kolicina:1', '2023-03-04 19:41:56'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 2 | kolicina:1', '2023-03-04 19:41:57'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 29 | kolicina:1', '2023-03-04 19:42:01'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 30 | kolicina:1', '2023-03-04 19:42:03'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 37 | kolicina:1', '2023-03-04 19:45:37'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 38 | kolicina:1', '2023-03-04 19:45:39'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 39 | kolicina:1', '2023-03-04 19:45:42'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 40 | kolicina:1', '2023-03-04 19:45:44'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 41 | kolicina:1', '2023-03-04 19:45:48'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 42 | kolicina:1', '2023-03-04 19:45:50'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 43 | kolicina:1', '2023-03-04 19:45:51'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 44 | kolicina:1', '2023-03-04 19:45:53'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 44 | kolicina:1', '2023-03-04 19:45:54'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 45 | kolicina:1', '2023-03-04 19:45:57'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 46 | kolicina:1', '2023-03-04 19:47:38'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 47 | kolicina:1', '2023-03-04 19:47:46'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 48 | kolicina:1', '2023-03-04 19:47:49'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 49 | kolicina:1', '2023-03-04 19:47:51'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 50 | kolicina:1', '2023-03-04 19:47:53'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 51 | kolicina:1', '2023-03-04 19:49:26'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 52 | kolicina:1', '2023-03-04 19:49:54'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 53 | kolicina:1', '2023-03-04 19:49:56'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 54 | kolicina:1', '2023-03-04 19:49:59'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 55 | kolicina:1', '2023-03-04 19:50:00'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 61 | kolicina:1', '2023-03-04 19:57:08'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 62 | kolicina:1', '2023-03-04 19:57:10'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 63 | kolicina:1', '2023-03-04 19:57:12'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 64 | kolicina:1', '2023-03-04 19:57:14'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 65 | kolicina:1', '2023-03-04 19:57:16'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 66 | kolicina:1', '2023-03-04 19:57:49'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 67 | kolicina:1', '2023-03-04 19:57:51'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 68 | kolicina:1', '2023-03-04 19:57:53'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 69 | kolicina:1', '2023-03-04 19:57:55'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 70 | kolicina:1', '2023-03-04 19:57:57'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-04 20:00:20'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -8000', '2023-03-04 20:23:24'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -10500', '2023-03-04 20:23:28'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -3646', '2023-03-04 20:23:31'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -1625', '2023-03-04 20:23:49'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -550', '2023-03-04 20:24:20'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -5800', '2023-03-04 20:24:49'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -5800', '2023-03-04 20:25:12'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -5800', '2023-03-04 20:25:36'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -5800', '2023-03-04 20:25:53'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-04 20:26:03'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-04 20:26:03'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-04 20:26:03'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 5000', '2023-03-04 20:26:40'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -40000', '2023-03-04 20:27:52'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-04 22:00:23'),
('1', 'Hadehd   Je dobio novac  Kolicina: -500', '2023-03-04 22:12:24'),
('1', 'Hadehd   Je dobio novac  Kolicina: -200', '2023-03-04 22:12:26'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-04 23:00:08'),
('3', 'Hadehd   je koristio /getcar : T092AM34', '2023-03-05 10:14:40'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-05 10:22:42'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-05 11:00:19'),
('3', 'Hadehd   popravlja vozilo /fixcar: P512OY83', '2023-03-05 11:14:01'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -4840', '2023-03-05 11:16:22'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -200', '2023-03-05 11:18:39'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:22:30'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:22:30'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:22:30'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:23:00'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:23:00'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:23:00'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:23:33'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:23:33'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:23:33'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:29:12'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:29:12'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:29:12'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:29:43'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:29:43'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:29:43'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:30:10'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:30:10'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -500', '2023-03-05 11:30:10'),
('3', 'Hadehd   popravlja vozilo /fixcar: P512OY83', '2023-03-05 11:31:01'),
('1', 'Hadehd   Je dobio novac  Kolicina: 20000', '2023-03-07 19:25:25'),
('1', 'Hadehd   Je dobio novac  Kolicina: 20000', '2023-03-07 19:25:25'),
('1', 'Hadehd   Je dobio novac  Kolicina: 20000', '2023-03-07 19:25:26'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-08 14:00:44'),
('12', 'Hadehd   Igrac Hadehd_ je ubio igraca  ', '2023-03-08 21:00:31'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-08 21:00:38'),
('3', 'Hadehd   je koristio /revive na: Hadehd ', '2023-03-08 21:03:13'),
('3', 'Hadehd   je koristio /getcar : T092AM34', '2023-03-08 21:17:36'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-09 14:00:54'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-09 15:00:30'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-09 16:00:18'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-09 21:00:34'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-10 16:00:55'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-11 11:00:11'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-11 12:00:11'),
('3', 'Hadehd   popravlja vozilo /fixcar: RPV-ADMIN', '2023-03-11 13:56:38'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-11 14:00:25'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-11 20:00:40'),
('3', 'Hadehd   popravlja vozilo /fixcar: RPV-ADMIN', '2023-03-11 20:52:35'),
('3', 'Hadehd   popravlja vozilo /fixcar: RPV-ADMIN', '2023-03-11 20:53:06'),
('3', 'Hadehd   popravlja vozilo /fixcar: RPV-ADMIN', '2023-03-11 20:53:50'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-11 21:00:03'),
('3', 'Hadehd   je koristio /getcar : P512OY83', '2023-03-13 14:27:18'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-13 15:00:37'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-13 16:00:55'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 5000', '2023-03-13 16:03:22'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -50000', '2023-03-13 16:23:48'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -50000', '2023-03-13 16:23:55'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -40000', '2023-03-13 16:23:59'),
('1', 'Hadehd   Je dobio novac  Kolicina: -50000', '2023-03-13 16:25:29'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 50000', '2023-03-13 16:25:29'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -50000', '2023-03-13 16:26:05');
INSERT INTO `server_log` (`log_type`, `log_message`, `log_time`) VALUES
('1', 'Hadehd   Je dobio novac  Kolicina: -82000', '2023-03-13 16:30:23'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 82000', '2023-03-13 16:30:23'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 0', '2023-03-13 16:33:47'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 0', '2023-03-13 16:33:52'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 0', '2023-03-13 16:34:04'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -10000', '2023-03-13 16:34:09'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -10000', '2023-03-13 16:34:14'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -10000', '2023-03-13 16:34:20'),
('3', 'Hadehd   je koristio /revive na: Hadehd ', '2023-03-13 16:46:50'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -124', '2023-03-13 16:55:49'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -1150', '2023-03-13 17:00:39'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 1 | kolicina:1', '2023-03-13 20:34:47'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 1 | kolicina:1', '2023-03-13 20:39:01'),
('3', 'Hadehd  je dao item igracu GTANetworkAPI.Player | ime itema: 2 | kolicina:1', '2023-03-13 20:45:32'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-14 18:00:27'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-14 19:00:44'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-14 19:11:01'),
('3', 'Hadehd   je /givemoney igracu: Hadehd  vrednost: 999999', '2023-03-14 19:16:56'),
('1', 'Hadehd   Je dobio novac  Kolicina: 999999', '2023-03-14 19:16:56'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-14 19:16:59'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 1', '2023-03-15 12:47:09'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-15 12:49:26'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-15 13:00:51'),
('1', 'Hadehd   Je dobio novac  Kolicina: -4000', '2023-03-15 13:19:20'),
('1', 'Hadehd   Je dobio novac  Kolicina: -555555', '2023-03-15 13:21:20'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 555555', '2023-03-15 13:21:20'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -52000', '2023-03-15 13:21:42'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 31200', '2023-03-15 13:22:12'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -145000', '2023-03-15 13:23:07'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -10500', '2023-03-15 13:25:22'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -3646', '2023-03-15 13:27:51'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -1625', '2023-03-15 13:27:56'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -1360', '2023-03-15 13:28:13'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -1100', '2023-03-15 13:28:23'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 5000', '2023-03-15 13:28:48'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -40000', '2023-03-15 13:28:56'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -11250', '2023-03-15 13:29:07'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-15 14:00:16'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-15 19:00:06'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-15 20:00:12'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-18 12:00:54'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-18 15:00:35'),
('3', 'Hadehd   popravlja vozilo /fixcar: RPV-ADMIN', '2023-03-18 16:14:20'),
('3', 'Hadehd   popravlja vozilo /fixcar: Y659BC05', '2023-03-18 16:17:39'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 10:58:33'),
('3', 'Hadehd   popravlja vozilo /fixcar: P988BM77', '2023-03-19 10:59:21'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 11:04:49'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-19 11:07:53'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 11:08:11'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 11:10:08'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-19 11:13:41'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 11:13:49'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 11:39:01'),
('3', 'Hadehd   je koristio /revive na: Hadehd ', '2023-03-19 11:40:17'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -110500', '2023-03-19 11:41:00'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -34000', '2023-03-19 11:42:31'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 12:11:42'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-19 12:15:31'),
('1', 'Hadehd   Je dobio novac  Kolicina: -400000', '2023-03-19 12:16:11'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 400000', '2023-03-19 12:16:11'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 12:16:22'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 12:32:40'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 12:36:03'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-19 12:43:18'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 12:43:33'),
('3', 'Hadehd   je koristio /freeze !: False', '2023-03-19 12:43:50'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-19 12:50:53'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 12:51:07'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -30000', '2023-03-19 12:55:03'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 12:58:13'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-19 12:58:56'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 12:59:32'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-19 13:01:47'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 13:01:59'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-19 13:07:48'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 13:08:00'),
('3', 'Hadehd   je koristio /getcar : 0', '2023-03-19 13:09:59'),
('3', 'Hadehd   je koristio /getcar : Y659BC05', '2023-03-19 13:10:08'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 13:15:58'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -110500', '2023-03-19 13:17:57'),
('1', 'Hadehd   Je dobio novac  Kolicina: -35000', '2023-03-19 13:26:43'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 35000', '2023-03-19 13:26:43'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 13:26:53'),
('3', 'Hadehd   je koristio /getcar : Y659BC05', '2023-03-19 13:40:03'),
('3', 'Hadehd   je /givemoney igracu: Hadehd  vrednost: 999999', '2023-03-19 13:43:37'),
('1', 'Hadehd   Je dobio novac  Kolicina: 999999', '2023-03-19 13:43:37'),
('1', 'Hadehd   Je dobio novac  Kolicina: -999999', '2023-03-19 13:43:49'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: 999999', '2023-03-19 13:43:49'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -34000', '2023-03-19 13:44:03'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -25000', '2023-03-19 13:47:33'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -99000', '2023-03-19 13:52:52'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-19 13:57:09'),
('3', 'Hadehd   popravlja vozilo /fixcar: RPV-ADMIN', '2023-03-25 18:46:31'),
('1', 'Hadehd   Je dobio novac  Kolicina: -100', '2023-03-25 21:59:10'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-25 22:00:56'),
('1', 'Hadehd   Je dobio novac  Kolicina: -100', '2023-03-25 22:02:10'),
('1', 'Hadehd   Je primio platu:  Kolicina: 9500', '2023-03-27 14:00:35'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-27 18:40:33'),
('3', 'Hadehd   je postavio dimenziju igracu: Hadehd ', '2023-03-27 18:43:13'),
('1', 'Hadehd   Je primio novac Banka:  Kolicina: -810000', '2023-03-27 18:49:27');

-- --------------------------------------------------------

--
-- Table structure for table `sms`
--

CREATE TABLE `sms` (
  `id` int(11) NOT NULL,
  `time` datetime DEFAULT NULL,
  `send_from_id` int(11) DEFAULT NULL,
  `send_from_name` varchar(64) DEFAULT NULL,
  `send_to_id` int(11) DEFAULT NULL,
  `send_to_name` varchar(64) DEFAULT NULL,
  `message` varchar(224) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `turfs`
--

CREATE TABLE `turfs` (
  `id` int(11) NOT NULL,
  `name` varchar(64) DEFAULT 'indefinido',
  `ownerid` int(11) DEFAULT -1,
  `vulnerable` int(11) DEFAULT 0,
  `capturedBy` varchar(64) DEFAULT 'nenhum',
  `position_x` varchar(64) DEFAULT '0.0000',
  `position_y` varchar(64) DEFAULT '0.0000',
  `position_z` varchar(64) DEFAULT '0.0000',
  `range` varchar(64) DEFAULT '0.0000',
  `payment` int(11) DEFAULT 500
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `turfs`
--

INSERT INTO `turfs` (`id`, `name`, `ownerid`, `vulnerable`, `capturedBy`, `position_x`, `position_y`, `position_z`, `range`, `payment`) VALUES
(0, 'T1', 8, 0, 'niko', '2322', '4872', '41', '60', 0),
(1, 'T2', 8, 0, 'niko', '518', '-2981', '6', '60', 0);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL DEFAULT '',
  `socialclubname` varchar(255) DEFAULT NULL,
  `password` char(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `betaAcess` int(11) DEFAULT 0,
  `FirstLogin` datetime(6) DEFAULT NULL,
  `isban` tinyint(1) DEFAULT 0,
  `banreason` varchar(512) DEFAULT '',
  `bannedby` varchar(50) DEFAULT '',
  `passq` varchar(50) DEFAULT NULL,
  `denyreason` varchar(512) DEFAULT '',
  `serial` varchar(200) DEFAULT '0',
  `logged` tinyint(4) NOT NULL DEFAULT 0,
  `refferal` varchar(50) DEFAULT '0',
  `invitedrefferal` varchar(50) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `vehicles`
--

CREATE TABLE `vehicles` (
  `id` int(11) NOT NULL,
  `vehicle_owner_id` int(11) DEFAULT NULL,
  `vehicle_model` varchar(255) DEFAULT NULL,
  `vehicle_plate` varchar(255) DEFAULT NULL,
  `vehicle_ticket` int(11) DEFAULT 0,
  `vehicle_state` int(11) DEFAULT 0,
  `vehicle_position_x` varchar(255) DEFAULT '0,0',
  `vehicle_position_y` varchar(255) DEFAULT '0,0',
  `vehicle_position_z` varchar(255) DEFAULT '0,0',
  `vehicle_rotation_x` varchar(255) DEFAULT '0,0',
  `vehicle_rotation_y` varchar(255) DEFAULT '0,0',
  `vehicle_rotation_z` varchar(255) DEFAULT '0,0',
  `vehicle_color_1` int(11) DEFAULT 0,
  `vehicle_color_2` int(11) DEFAULT 0,
  `vehicle_dimension` int(11) DEFAULT 0,
  `vehicle_engine` int(11) DEFAULT -1,
  `vehicle_brakes` int(11) DEFAULT -1,
  `vehicle_suspesion` int(11) DEFAULT -1,
  `vehicle_armor` int(11) DEFAULT -1,
  `crash_x` varchar(255) DEFAULT '0,0',
  `crash_y` varchar(255) DEFAULT '0,0',
  `crash_z` varchar(255) DEFAULT '0,0',
  `crash_a` varchar(255) DEFAULT '0,0',
  `crash_flag` datetime(6) DEFAULT NULL,
  `mods` varchar(2024) DEFAULT '0',
  `health` int(11) DEFAULT 1000,
  `fuel` int(11) DEFAULT 100,
  `isforsale` int(11) DEFAULT 0,
  `price` int(11) DEFAULT 0,
  `veh_osiguranje` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `vehicle_inventory`
--

CREATE TABLE `vehicle_inventory` (
  `id` int(11) NOT NULL,
  `vehicle` int(11) DEFAULT 0,
  `type` int(11) DEFAULT 0,
  `amount` int(11) DEFAULT 0,
  `slotid` int(11) DEFAULT -1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Table structure for table `warrant`
--

CREATE TABLE `warrant` (
  `id` int(11) NOT NULL,
  `date` datetime NOT NULL DEFAULT current_timestamp(),
  `suspect` varchar(50) NOT NULL,
  `description` varchar(512) NOT NULL,
  `jailtime` smallint(6) NOT NULL DEFAULT 0,
  `officer` varchar(50) NOT NULL DEFAULT '0',
  `isopen` tinyint(4) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `business`
--
ALTER TABLE `business`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `business_type_dealership_points`
--
ALTER TABLE `business_type_dealership_points`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `business_vehicles`
--
ALTER TABLE `business_vehicles`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `characters`
--
ALTER TABLE `characters`
  ADD PRIMARY KEY (`id`,`userid`) USING BTREE;

--
-- Indexes for table `companies`
--
ALTER TABLE `companies`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `contacts`
--
ALTER TABLE `contacts`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `crime_report`
--
ALTER TABLE `crime_report`
  ADD PRIMARY KEY (`id`) USING BTREE,
  ADD UNIQUE KEY `id` (`id`) USING BTREE,
  ADD KEY `issuer` (`office`) USING BTREE,
  ADD KEY `suspect` (`suspect`) USING BTREE;

--
-- Indexes for table `custom_farm`
--
ALTER TABLE `custom_farm`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `faction`
--
ALTER TABLE `faction`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `faction_invite`
--
ALTER TABLE `faction_invite`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `faction_rank`
--
ALTER TABLE `faction_rank`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `faction_werehouse`
--
ALTER TABLE `faction_werehouse`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `fines`
--
ALTER TABLE `fines`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `furnitures`
--
ALTER TABLE `furnitures`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `garagem`
--
ALTER TABLE `garagem`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `garbages`
--
ALTER TABLE `garbages`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `glog`
--
ALTER TABLE `glog`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `govcamera`
--
ALTER TABLE `govcamera`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `houses`
--
ALTER TABLE `houses`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `inventory_house`
--
ALTER TABLE `inventory_house`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `inventory_hq`
--
ALTER TABLE `inventory_hq`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `kenny_applications`
--
ALTER TABLE `kenny_applications`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `kenny_badges`
--
ALTER TABLE `kenny_badges`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `kenny_comments`
--
ALTER TABLE `kenny_comments`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `kenny_complaints`
--
ALTER TABLE `kenny_complaints`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `kenny_editables`
--
ALTER TABLE `kenny_editables`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `kenny_logs`
--
ALTER TABLE `kenny_logs`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `kenny_questions`
--
ALTER TABLE `kenny_questions`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `kenny_recovery`
--
ALTER TABLE `kenny_recovery`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `kenny_tickets`
--
ALTER TABLE `kenny_tickets`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `kenny_unbans`
--
ALTER TABLE `kenny_unbans`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `known`
--
ALTER TABLE `known`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `mdc`
--
ALTER TABLE `mdc`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `notes`
--
ALTER TABLE `notes`
  ADD PRIMARY KEY (`id`) USING BTREE,
  ADD UNIQUE KEY `id` (`id`) USING BTREE,
  ADD KEY `suspect` (`suspect`) USING BTREE,
  ADD KEY `issuer` (`officer`) USING BTREE;

--
-- Indexes for table `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `pdbadge`
--
ALTER TABLE `pdbadge`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `pquest`
--
ALTER TABLE `pquest`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `quests`
--
ALTER TABLE `quests`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `sellingcar`
--
ALTER TABLE `sellingcar`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `sms`
--
ALTER TABLE `sms`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `turfs`
--
ALTER TABLE `turfs`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`,`username`) USING BTREE;

--
-- Indexes for table `vehicles`
--
ALTER TABLE `vehicles`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `vehicle_inventory`
--
ALTER TABLE `vehicle_inventory`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `warrant`
--
ALTER TABLE `warrant`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `business_vehicles`
--
ALTER TABLE `business_vehicles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `characters`
--
ALTER TABLE `characters`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;

--
-- AUTO_INCREMENT for table `contacts`
--
ALTER TABLE `contacts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `crime_report`
--
ALTER TABLE `crime_report`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `custom_farm`
--
ALTER TABLE `custom_farm`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `faction_invite`
--
ALTER TABLE `faction_invite`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `fines`
--
ALTER TABLE `fines`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `furnitures`
--
ALTER TABLE `furnitures`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `glog`
--
ALTER TABLE `glog`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `govcamera`
--
ALTER TABLE `govcamera`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `inventory_house`
--
ALTER TABLE `inventory_house`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `inventory_hq`
--
ALTER TABLE `inventory_hq`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=986;

--
-- AUTO_INCREMENT for table `kenny_applications`
--
ALTER TABLE `kenny_applications`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `kenny_badges`
--
ALTER TABLE `kenny_badges`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `kenny_comments`
--
ALTER TABLE `kenny_comments`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `kenny_complaints`
--
ALTER TABLE `kenny_complaints`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `kenny_editables`
--
ALTER TABLE `kenny_editables`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `kenny_logs`
--
ALTER TABLE `kenny_logs`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `kenny_questions`
--
ALTER TABLE `kenny_questions`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `kenny_recovery`
--
ALTER TABLE `kenny_recovery`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `kenny_tickets`
--
ALTER TABLE `kenny_tickets`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `kenny_unbans`
--
ALTER TABLE `kenny_unbans`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `known`
--
ALTER TABLE `known`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mdc`
--
ALTER TABLE `mdc`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notes`
--
ALTER TABLE `notes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `payment`
--
ALTER TABLE `payment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pdbadge`
--
ALTER TABLE `pdbadge`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pquest`
--
ALTER TABLE `pquest`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `quests`
--
ALTER TABLE `quests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sellingcar`
--
ALTER TABLE `sellingcar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sms`
--
ALTER TABLE `sms`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=414;

--
-- AUTO_INCREMENT for table `vehicles`
--
ALTER TABLE `vehicles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;

--
-- AUTO_INCREMENT for table `vehicle_inventory`
--
ALTER TABLE `vehicle_inventory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `warrant`
--
ALTER TABLE `warrant`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
