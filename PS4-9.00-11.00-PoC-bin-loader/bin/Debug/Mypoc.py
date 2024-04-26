from scapy.all import PPPoED, Ether, sniff, sendp, srp1
import binascii
import os

source = b"\x4C\xCC\x6A\x83\xD5\x95"
destination = b"\x22\x22\x22\x22\x22\x22"
interface = "Realtek PCIe 2.5GbE Family Controller #2"

payload_dir = input("Enter the path to the payload directory: ")

payload_file = os.path.join(payload_dir, "payload.bin")
with open(payload_file, "rb") as file:
    payload_data = file.read()

packet = sniff(iface=interface, filter="pppoed", count=1)
tag_value = packet[PPPoED][0].tag_list[1].tag_value

pppoed_packet = Ether(dst=destination, src=source) / PPPoED() / payload_data
pppoed_packet.tag_list[1].tag_value = tag_value

sendp(pppoed_packet, iface=interface)

packet = sniff(iface=interface, filter="pppoed", count=1)
tag_value = packet[PPPoED][0].tag_list[1].tag_value

pppoed_packet = Ether(dst=destination, src=source) / PPPoED() / payload_data
pppoed_packet.tag_list[1].tag_value = tag_value

sendp(pppoed_packet, iface=interface)

packet = sniff(iface=interface, filter="pppoes", count=1)
tag_value = packet[0][PPPoED][0].tag_list[1].tag_value

pppoes_packet = Ether(dst=destination, src=source) / PPPoED() / payload_data
pppoes_packet.tag_list[1].tag_value = tag_value

response = srp1(pppoes_packet, iface=interface)

if response:
    response_hexdump = binascii.hexlify(bytes(response))
    print("Response Hexdump:", response_hexdump)
else:
    print("No response received.")

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
