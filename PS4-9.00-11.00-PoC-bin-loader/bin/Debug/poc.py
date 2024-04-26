from scapy.all import PPPoED, Ether, sniff, sendp, srp1
import binascii
import os

# MAC address of your adapter on PC
source = b"\xXX\xXX\xXX\xXX\xXX\xXX"
# MAC address of LAN on your PS4
destination = b"\xXX\xXX\xXX\xXX\xXX\xXX"
# Network interface name on your PC
interface = "Realtek PCIe 2.5GbE Family Controller #2"

# Ask for the payload directory input
payload_dir = input("Enter the path to the payload directory: ")

# Load your payload binary file
payload_file = os.path.join(payload_dir, "payload.bin")
with open(payload_file, "rb") as file:
    payload_data = file.read()

# Sniff for a single PPPoED packet to extract tag value
packet = sniff(iface=interface, filter="pppoed", count=1)
tag_value = packet[PPPoED][0].tag_list[1].tag_value

# Craft the PPPoED packet to load the payload
pppoed_packet = Ether(dst=destination, src=source) / PPPoED() / payload_data
pppoed_packet.tag_list[1].tag_value = tag_value

# Send the crafted packet
sendp(pppoed_packet, iface=interface)

# Sniff for a single PPPoED packet again
packet = sniff(iface=interface, filter="pppoed", count=1)
tag_value = packet[PPPoED][0].tag_list[1].tag_value

# Craft another PPPoED packet to load the payload
pppoed_packet = Ether(dst=destination, src=source) / PPPoED() / payload_data
pppoed_packet.tag_list[1].tag_value = tag_value

# Send the crafted packet
sendp(pppoed_packet, iface=interface)

# Sniff for a single PPPoES packet
packet = sniff(iface=interface, filter="pppoes", count=1)
tag_value = packet[0][PPPoED][0].tag_list[1].tag_value

# Craft the PPPoES packet to load the payload
pppoes_packet = Ether(dst=destination, src=source) / PPPoED() / payload_data
pppoes_packet.tag_list[1].tag_value = tag_value

# Send the crafted packet and receive response
response = srp1(pppoes_packet, iface=interface)

# Print the response hexdump
if response:
    response_hexdump = binascii.hexlify(bytes(response))
    print("Response Hexdump:", response_hexdump)
else:
    print("No response received.")

# Craft and send multiple packets to load the payload
success_count = 0
failure_count = 0
for i in range(20):
    sendp(pppoes_packet, iface=interface)
    if sniff(iface=interface, filter="pppoed", count=1):
        success_count += 1
    else:
        failure_count += 1

print("Successful attempts:", success_count)
print("Failed attempts:", failure_count)
